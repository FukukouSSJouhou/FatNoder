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
            INamedTypeSymbol XMLModelSymbol = context.Compilation.GetTypeByMetadataName("FatNoder.Serializer.Node.Xml.XML_NodeModel");
            INamedTypeSymbol XMLNodeXYSymbol = context.Compilation.GetTypeByMetadataName("FatNoder.Serializer.Node.Xml.XMLNodeXY");
            foreach (IGrouping<INamedTypeSymbol, IFieldSymbol> group in reciever.Fields.GroupBy<IFieldSymbol, INamedTypeSymbol>(f => f.ContainingType, SymbolEqualityComparer.Default))
            {
                string src = ProcClass(group.Key,XMLModelSymbol, XMLNodeXYSymbol,group.ToList(), attributeSymbol, context);
                context.AddSource($"{group.Key.Name}_AyanoNodeVM.g.cs", SourceText.From(src, Encoding.UTF8));
            }
        }
        private string ProcClass(INamedTypeSymbol symbol, INamedTypeSymbol XMLModelSymbol,INamedTypeSymbol XMLNodeXYSymbol,List<IFieldSymbol> fields, ISymbol attributeSymbol, GeneratorExecutionContext context)
        {
            if (!symbol.ContainingSymbol.Equals(symbol.ContainingNamespace, SymbolEqualityComparer.Default)){
                return null;
            }
            string NSName = symbol.ContainingNamespace.ToDisplayString();
            string CLSName = symbol.Name;
            StringBuilder src = new StringBuilder("");
            if (symbol.IsGenericType)
            {
                CLSName += $"<{symbol.TypeParameters[0].ToDisplayString()}";
                for (int i = 1; i < symbol.TypeParameters.Length; i++)
                {

                    CLSName+= $",{symbol.TypeParameters[i].ToDisplayString()}";
                }
                CLSName += ">";
            }
                src.Append($@"
using System.Reactive;
using System.Reactive.Linq;
using System;
namespace {NSName}
{{
    public partial class {CLSName}
    {{
");
            string XMLSymkun=XMLModelSymbol.ToDisplayString();
            string XMLNodeXYSymbolkun = XMLNodeXYSymbol.ToDisplayString();
            foreach (IFieldSymbol symf in fields)
            {
                ProcField(src, symf, XMLSymkun, CLSName, XMLNodeXYSymbolkun);
            }
            src.Append("} }");
            return src.ToString();
        }
        private void ProcField(StringBuilder src, IFieldSymbol fSymbol, string XMLModelSymbol, string CLSName, string XMLNodeXYName)
        {
            string fName=fSymbol.Name;
            ITypeSymbol fType = fSymbol.Type;
            if (fName == "model") return;
            src.Append($@"
        public {XMLModelSymbol} model {{
            get {{
                return this.{fName};
            }}
        }}
");
            src.Append($@"
        private void InitAyanoVMB()
        {{
            this.{fName}.TYPE = typeof({CLSName}).AssemblyQualifiedName;
            this.{fName}.MODELTYPE = fName.GetType().AssemblyQualifiedName;
            this.UUIDChanged.Subscribe(newvalue =>
            {{
                {fName}.UUID = newvalue;
            }});
            this.NameChanged.Subscribe(newvalue =>
            {{
                {fName}.Name = newvalue;
            }});
            this.PositionChanged.Subscribe(newvalue =>
            {{
                {fName}.Points = new {XMLNodeXYName}()
                {{
                    X = newvalue.X,
                    Y = newvalue.Y
                }};
            }});
   
        }}
");
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
