using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
namespace NodeAyanoVMLibsCodeGenerator
{
    [Generator]
    public class AyanoNodeVMGenerator : ISourceGenerator
    {
        private const string attributeText = @"
using System;
namespace AyanoNodeVM
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    [System.Diagnostics.Conditional(""AyanoNodeVMGenerator_DEBUG"")]
    sealed class ModelAyanoAttribute:Attribute
    {
        public ModelAyanoAttribute(){
            
        }
    }
}
";
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForPostInitialization((i) => i.AddSource("ModelAyanoAttribute.g.cs", attributeText));
            context.RegisterForSyntaxNotifications(() => new SyntaxReciever());
        }
        public void Execute(GeneratorExecutionContext context)
        {
            if (!(context.SyntaxContextReceiver is SyntaxReciever reciever))
                return;
            INamedTypeSymbol attributeSymbol = context.Compilation.GetTypeByMetadataName("AyanoNodeVM.ModelAyanoAttribute");
            foreach(IGrouping<INamedTypeSymbol, IFieldSymbol> group in reciever.Fields.GroupBy<IFieldSymbol, INamedTypeSymbol>(f => f.ContainingType, SymbolEqualityComparer.Default))
            {
                string src = ProcClass(group.Key, group.ToList(), attributeSymbol, context);
                context.AddSource($"{group.Key.Name}_AyanoNodeVM.g.cs", SourceText.From(src, Encoding.UTF8));
            }
        }
        private string ProcClass(INamedTypeSymbol symbol,List<IFieldSymbol> fields, ISymbol attributeSymbol, GeneratorExecutionContext context)
        {
            return "";
        }
    }
    class SyntaxReciever : ISyntaxContextReceiver
    {
        public List<IFieldSymbol> Fields { get; }= new List<IFieldSymbol>();
        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            if(context.Node is FieldDeclarationSyntax cNode && cNode.AttributeLists.Count > 0)
            {
                foreach(VariableDeclaratorSyntax v in cNode.Declaration.Variables)
                {
                    IFieldSymbol sym = context.SemanticModel.GetDeclaredSymbol(v) as IFieldSymbol;
                    if(sym.GetAttributes().Any(ad=>ad.AttributeClass.ToDisplayString()== "AyanoNodeVM.ModelAyanoAttribute"))
                    {
                        Fields.Add(sym);
                    }
                }
            }
        }
    }
}
