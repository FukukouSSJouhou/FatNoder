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
        private const string sourceCode = @"
using System;
namespace tintin{
    class tinpo{
    static void Main(){
    }
    }
}";
        /// <summary>
        /// Compile
        /// </summary>
        /// <param name="NodeEnum">Node</param>
        /// <param name="clsName">clsName</param>
        /// <param name="nsName">Namespace Name</param>
        /// <returns>C# str</returns>
        public static string Compile(NodeModelEnumerator NodeEnum, string clsName = "testMainCls", string nsName="TEST123")
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
            var rootNode = syntaxTree.GetRoot();
            var namespaceNode = rootNode.DescendantNodes().First(node => node.GetType() == typeof(NamespaceDeclarationSyntax));
            var namespaceSyntaxkun = namespaceNode.DescendantNodes().First(node => node.GetType() == typeof(IdentifierNameSyntax));
            SyntaxNode OldNode;
            var SCLS = CreateClass(clsName);
            var namespaceNode2 = namespaceNode.ReplaceNode(
                oldNode: namespaceSyntaxkun,
                newNode: SyntaxFactory.IdentifierName(nsName))
                ;
            var newnode = rootNode.ReplaceNode(
                oldNode: namespaceNode,
                newNode: namespaceNode2);
            var SCLSMethodLists = SyntaxFactory.List<MemberDeclarationSyntax>();
            if (rootNode is IMethodPointBase)
            {

            }
            else
            {
                MethodDeclarationSyntax methodkun = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName("int"), SyntaxFactory.Identifier("Metkun"));
                SCLSMethodLists= SCLSMethodLists.Add(methodkun);
            }
            SCLS = SCLS.WithMembers(SCLSMethodLists);
            OldNode = newnode;
            {
                var oldcls = OldNode.DescendantNodes().First(node => node.GetType() == typeof(ClassDeclarationSyntax));
                newnode = OldNode.ReplaceNode(
                    oldNode: oldcls,
                    newNode: SCLS);
            }
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
