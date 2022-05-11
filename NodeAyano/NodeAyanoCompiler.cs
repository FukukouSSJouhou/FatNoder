using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Emit;
using NodeAyano.ASMC;
using NodeAyano.Model.Enumerator;
using NodeAyano.Model.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
        /// <summary>
        /// Compile
        /// </summary>
        /// <param name="NodeEnum">Node</param>
        /// <param name="clsName">clsName</param>
        /// <param name="nsName">Namespace Name</param>
        /// <returns>C# SyntaxNode</returns>
        public static CompilationUnitSyntax TransCompileNode(NodeModelEnumerator NodeEnum, string clsName = "testMainCls", string nsName = "TEST123")
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
                    statements.Add(
                                        SyntaxFactory.ExpressionStatement(
                    SyntaxFactory.InvocationExpression(
                        SyntaxFactory.MemberAccessExpression(
                                SyntaxKind.SimpleMemberAccessExpression,
                                SyntaxFactory.IdentifierName("Console.Error"),
                                SyntaxFactory.IdentifierName("WriteLine")
                            ),
                        SyntaxFactory.ArgumentList(
                            SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                new ArgumentSyntax[1]{SyntaxFactory.Argument(
                                SyntaxFactory.IdentifierName("id_" + "X_PrintErrcontent")
                            ) }

                        )
                    ))));
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
            return newnode;
        }
        /// <summary>
        /// TransCompile
        /// </summary>
        /// <param name="NodeEnum">Node</param>
        /// <param name="clsName">clsName</param>
        /// <param name="nsName">Namespace Name</param>
        /// <returns>C# String</returns>
        public static string TransCompile(NodeModelEnumerator NodeEnum, string clsName = "testMainCls", string nsName = "TEST123")
        {
            return TransCompileNode(NodeEnum, clsName, nsName).NormalizeWhitespace().ToString();
        }
        private static ClassDeclarationSyntax CreateClass(string name)
        {

            return SyntaxFactory.ClassDeclaration(name).AddModifiers(new SyntaxToken[1] { SyntaxFactory.Token(SyntaxKind.PublicKeyword) });
        }
        public static void CompileToFile(string code, string filename, string clsName = "testMainCls", string nsName = "TEST123")
        {

            var assemblyDirectoryPath = Path.GetDirectoryName(typeof(object).Assembly.Location);
            var references = new MetadataReference[]
            {
            MetadataReference.CreateFromFile(
            $"{assemblyDirectoryPath}/mscorlib.dll"),
        MetadataReference.CreateFromFile(
            $"{assemblyDirectoryPath}/System.Runtime.dll"),
        MetadataReference.CreateFromFile(
            $"{assemblyDirectoryPath}/System.Console.dll"),
        MetadataReference.CreateFromFile(
            $"{assemblyDirectoryPath}/System.Private.CoreLib.dll"),
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
                OutputKind.ConsoleApplication,
                mainTypeName: $"{nsName}.{clsName}"
            );

            var compilation = CSharpCompilation.Create(
                clsName + ".exe",
                new[] { syntaxTree },
                references,
                compilationOptions
            );
            var emOptions = new EmitOptions(includePrivateMembers: true)
            {

            };
            using (Stream stream = new FileStream(filename, FileMode.OpenOrCreate))
            {
                var emitResult = compilation.Emit(stream, options: emOptions);

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

            }

        }
        /// <summary>
        /// Code Analyze!
        /// </summary>
        /// <param name="code">code</param>
        /// <param name="diag">func</param>
        /// <param name="clsName">clsname</param>
        /// <param name="nsName">namespace name</param>
        public static void Analyzekun(string code, Action<Diagnostic> diag, string clsName = "testMainCls", string nsName = "TEST123")
        {

            var parseOptions = CSharpParseOptions.Default
                .WithLanguageVersion(LanguageVersion.CSharp10);

            var syntaxTree = CSharpSyntaxTree.ParseText(
                code,
                parseOptions
            );
            foreach(var diagkun in syntaxTree.GetDiagnostics())
            {
                diag(diagkun);
            }

        }

        /// <summary>
        ///  Compile and Exec
        /// </summary>
        /// <param name="code">code</param>
        /// <param name="wref">WREF</param>
        /// <param name="clsName">CLS Name</param>
        /// <param name="nsName">nsName</param>
        [MethodImpl(MethodImplOptions.NoInlining)]

        public static void CompileAndRunExec(string code, out WeakReference wref, string clsName = "testMainCls", string nsName = "TEST123")
        {
            CompileAndRunExec(code, d =>
            {
                var pos = d.Location.GetLineSpan();
                var location = "(" + pos.Path + "@Line" + (pos.StartLinePosition.Line + 1) + ":" + (pos.StartLinePosition.Character + 1) + ")";
                Console.WriteLine($"[{d.Severity}, {location}] {d.Id}, {d.GetMessage()}");

            }, out wref, clsName, nsName);
        }
        /// <summary>
        /// Compile and Exec
        /// </summary>
        /// <param name="code">Code</param>
        /// <param name="diagOut">Diag out</param>
        /// <param name="wref">WREF</param>
        /// <param name="clsName">CLS Name</param>
        /// <param name="nsName">Namespace Name</param>
        /// <exception cref="ArgumentException"></exception>
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CompileAndRunExec(string code, Action<Diagnostic> diagOut, out WeakReference wref, string clsName = "testMainCls", string nsName = "TEST123")
        {

            var assemblyDirectoryPath = Path.GetDirectoryName(typeof(object).Assembly.Location);
            var references = new MetadataReference[]
            {
            MetadataReference.CreateFromFile(
            $"{assemblyDirectoryPath}/mscorlib.dll"),
        MetadataReference.CreateFromFile(
            $"{assemblyDirectoryPath}/System.Runtime.dll"),
        MetadataReference.CreateFromFile(
            $"{assemblyDirectoryPath}/System.Console.dll"),
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
                OutputKind.ConsoleApplication,
                mainTypeName: $"{nsName}.{clsName}"
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
                    /* example
                    var pos = diagnostic.Location.GetLineSpan();
                    var location = "(" + pos.Path + "@Line" + (pos.StartLinePosition.Line + 1) + ":" + (pos.StartLinePosition.Character + 1) + ")";
                    Console.WriteLine($"[{diagnostic.Severity}, {location}] {diagnostic.Id}, {diagnostic.GetMessage()}");
                    */
                    diagOut(diagnostic);
                }

                if (!emitResult.Success)
                {
                    throw new ArgumentException("Compile error occured.");
                }
                stream.Seek(0, SeekOrigin.Begin);
                var ASC = new AyanoAssemblyLoadContext();
                var asm = ASC.LoadFromStream(stream);
                wref = new WeakReference(ASC, trackResurrection: true);
                asm.EntryPoint.Invoke(null, null);
                ASC.Unload();


            }

        }
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CompileAndRunExec(CompilationUnitSyntax code, out WeakReference wref, string clsName = "testMainCls", string nsName = "TEST123")
        {

            var assemblyDirectoryPath = Path.GetDirectoryName(typeof(object).Assembly.Location);
            var references = new MetadataReference[]
            {
            MetadataReference.CreateFromFile(
            $"{assemblyDirectoryPath}/mscorlib.dll"),
        MetadataReference.CreateFromFile(
            $"{assemblyDirectoryPath}/System.Runtime.dll"),
        MetadataReference.CreateFromFile(
            $"{assemblyDirectoryPath}/System.Console.dll"),
        MetadataReference.CreateFromFile(
            typeof(object).Assembly.Location)
            };

            var parseOptions = CSharpParseOptions.Default
                .WithLanguageVersion(LanguageVersion.CSharp10);

            var syntaxTree = CSharpSyntaxTree.Create(
                code,
                parseOptions
            );

            var compilationOptions = new CSharpCompilationOptions(
                OutputKind.ConsoleApplication,
                mainTypeName: $"{nsName}.{clsName}"
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
                var ASC = new AyanoAssemblyLoadContext();
                var asm = ASC.LoadFromStream(stream);
                wref = new WeakReference(ASC, trackResurrection: true);
                asm.EntryPoint.Invoke(null, null);
                ASC.Unload();


            }

        }
    }
}
