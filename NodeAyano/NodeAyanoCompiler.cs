using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NodeAyano.Model.Enumerator;
using NodeAyano.Model.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public static string Compile(NodeModelEnumerator NodeEnum, string clsName = "testMainCls", string nsName="TEST123")
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
                if(NodeEnum.Current is IMethodPointBase)
                {

                }
            }
            else
            {
                MethodDeclarationSyntax methodkun = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName("int"), SyntaxFactory.Identifier("Metkun"));
                var statements = new List<StatementSyntax>();
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
            NodeEnum.Reset();
            while (NodeEnum.MoveNext())
            {

            }
            return "";
        }
        private static ClassDeclarationSyntax CreateClass(string name)
        {

            return SyntaxFactory.ClassDeclaration(name);
        }
    }
}
