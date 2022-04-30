using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NodeAyano.Model.Enumerator;
using NodeAyano.Model.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyano
{
    /// <summary>
    /// Compiler??
    /// </summary>
    public class NodeAyanoCompiler
    {
        /*private const string sourceCode = @"
using System;
namespace tintin{
    class tinpo{
    static void Main(){
    }
    }
}";*/
        /// <summary>
        /// Compile
        /// </summary>
        /// <param name="NodeEnum">Node</param>
        /// <param name="clsName">clsName</param>
        /// <param name="nsName">Namespace Name</param>
        /// <returns>C# str</returns>
        public static string TransCompile(NodeModelEnumerator NodeEnum, string clsName = "testMainCls", string nsName = "TEST123")
        {
            var compUnit = SyntaxFactory.CompilationUnit();
            var CLSList = new List<MemberDeclarationSyntax>();
            var NSList = new List<MemberDeclarationSyntax>();
            var USList = new List<UsingDirectiveSyntax>();
            var SCLS = CreateClass(clsName);
            var nsNode = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName(nsName));

            var newnode = compUnit;
            var SCLSMethodLists = new List<MemberDeclarationSyntax>();
            USList.Add(SyntaxFactory.UsingDirective(SyntaxFactory.IdentifierName("System")));
            if (NodeEnum != null)
            {
                NodeEnum.Reset();
                MethodDeclarationSyntax methodkun;
                var statements = new List<StatementSyntax>();
                NodeEnum.MoveNext();

                if (NodeEnum.Current is IMethodPointBase)
                {
                    methodkun = ((IMethodPointBase)NodeEnum.Current).CompileMethodSyntax();

                    while (NodeEnum.MoveNext())
                    {
                        if (NodeEnum.Current is CompileNodeBase)
                        {
                            foreach (StatementSyntax sckun in ((CompileNodeBase)NodeEnum.Current).CompileSyntax())
                            {
                                statements.Add(sckun);
                            }
                        }
                    }
                    methodkun = methodkun.AddBodyStatements(statements.ToArray());
                    SCLSMethodLists.Add(methodkun);
                }
            }
            else
            {
                MethodDeclarationSyntax methodkun = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName("int"), SyntaxFactory.Identifier("Metkun"));
                var statements = new List<StatementSyntax>();
                {
                    PredefinedTypeSyntax predeftype = SyntaxFactory.PredefinedType(SyntaxFactory.ParseToken("int"));
                    List<VariableDeclaratorSyntax> vardecatorsynlist = new();
                    VariableDeclarationSyntax valdeckun = SyntaxFactory.VariableDeclaration(predeftype);
                    {
                        VariableDeclaratorSyntax decr = SyntaxFactory.VariableDeclarator("tdn34");
                        decr = decr.WithInitializer(
                            SyntaxFactory.EqualsValueClause(SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(
                                810)))
                            );
                        vardecatorsynlist.Add(decr);
                    }
                    valdeckun = valdeckun.AddVariables(vardecatorsynlist.ToArray());
                    LocalDeclarationStatementSyntax localdec = SyntaxFactory.LocalDeclarationStatement(valdeckun);
                    statements.Add(localdec);
                }
                {
                    ReturnStatementSyntax retstatement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("tdn34"));
                    statements.Add(retstatement);
                }
                //statements.Add(SyntaxFactory.Block());
                methodkun = methodkun.AddBodyStatements(statements.ToArray());
                SCLSMethodLists.Add(methodkun);
            }
            SCLS = SCLS.AddMembers(SCLSMethodLists.ToArray());
            CLSList.Add(SCLS);
            nsNode = nsNode.AddMembers(CLSList.ToArray());
            NSList.Add(nsNode);
            newnode = newnode.AddUsings(USList.ToArray());
            newnode = newnode.AddMembers(NSList.ToArray());

            return (newnode.NormalizeWhitespace().ToString());
        }
        private static ClassDeclarationSyntax CreateClass(string name)
        {

            return SyntaxFactory.ClassDeclaration(name).AddModifiers(new SyntaxToken[1] { SyntaxFactory.Token(SyntaxKind.PublicKeyword) });
        }
        public static Assembly Compile(string code, string clsName = "testMainCls", string nsName = "TEST123")
        {

            var assemblyDirectoryPath = Path.GetDirectoryName(typeof(object).Assembly.Location);
            var references = new MetadataReference[]
            {
            MetadataReference.CreateFromFile( 
            $"{assemblyDirectoryPath}/mscorlib.dll"),
        MetadataReference.CreateFromFile(
            $"{assemblyDirectoryPath}/System.Runtime.dll"),
        MetadataReference.CreateFromFile(
            typeof(object).Assembly.Location)
            };

            var parseOptions = CSharpParseOptions.Default
                .WithLanguageVersion(LanguageVersion.CSharp10);

            var syntaxTree = CSharpSyntaxTree.ParseText(
                code,
                parseOptions
            );

            var compilationOptions = new CSharpCompilationOptions(
                OutputKind.ConsoleApplication
            );

            var compilation = CSharpCompilation.Create(
                clsName,
                new[] { syntaxTree },
                references,
                compilationOptions
            );

            using (var stream = new MemoryStream())
            {
                var emitResult = compilation.Emit(stream);

                foreach (var diagnostic in emitResult.Diagnostics)
                {
                    var pos = diagnostic.Location.GetLineSpan();
                    var location = "(" + pos.Path + "@Line" + (pos.StartLinePosition.Line + 1) + ":" + (pos.StartLinePosition.Character + 1) + ")";
                    Console.WriteLine($"[{diagnostic.Severity}, {location}] {diagnostic.Id}, {diagnostic.GetMessage()}");
                }

                if (!emitResult.Success)
                {
                    throw new ArgumentException("Compile error occured.");
                }

                stream.Seek(0, SeekOrigin.Begin);
                return AssemblyLoadContext.Default.LoadFromStream(stream);
            }

        }
    }
}
