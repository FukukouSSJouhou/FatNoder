using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NodeAyano.Model.Enumerator;
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
        /// <returns>C# str</returns>
        public static string Compile(NodeModelEnumerator NodeEnum)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
            var rootNode = syntaxTree.GetRoot();
            string nsName = "TEST123";
            var namespaceNode = rootNode.DescendantNodes().First(node => node.GetType() == typeof(NamespaceDeclarationSyntax));
            var namespaceSyntaxkun = namespaceNode.DescendantNodes().First(node => node.GetType() == typeof(IdentifierNameSyntax));
            var namespaceNode2 = namespaceNode.ReplaceNode(
                oldNode: namespaceSyntaxkun,
                newNode: SyntaxFactory.IdentifierName(nsName))
                ;
            var newnode = rootNode.ReplaceNode(
                oldNode: namespaceNode,
                newNode: namespaceNode2);
            return (newnode.NormalizeWhitespace().ToString());
            NodeEnum.Reset();
            while (NodeEnum.MoveNext())
            {

            }
            return "";
        }
    }
}
