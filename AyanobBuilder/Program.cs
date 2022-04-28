using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FatNoder
{
    class Walker : SyntaxWalker // Visitor パターンでソースコードを解析
    {
        public override void Visit(SyntaxNode node) // 各ノードを Visit
        {
            if (node != null)
                Console.WriteLine("[Node  - Type: {0}, Kind: {1}]\n{2}\n", node.GetType().Name, node.Kind, node);

            base.Visit(node);
        }
    }
    
    public class AyanoBuilder
    {
        static NamespaceDeclarationSyntax CreateNameSpaceSyntax(SyntaxList<AttributeListSyntax> attributeLists, SyntaxTokenList modifiers, string namekun, SyntaxList<ExternAliasDirectiveSyntax> externs, SyntaxList<UsingDirectiveSyntax> usings, SyntaxList<MemberDeclarationSyntax> members)
        {
            var namesyntax= SyntaxFactory.IdentifierName(namekun);
            return SyntaxFactory.NamespaceDeclaration(attributeLists,modifiers,namesyntax,externs,usings,members);
        }
        public static int Main(string[] args)
        {
            Console.WriteLine("TDN");
            var sourceCode = @"
using System;
namespace tintin{
    class tinpo{
    static void Main(){
    }
    }
}";
            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
            var rootNode = syntaxTree.GetRoot();
            //new Walker().Visit(rootNode);
            //Console.ReadKey();
            var namespaceNode = rootNode.DescendantNodes().First(node => node.GetType() == typeof(NamespaceDeclarationSyntax));
            var newnode = rootNode.ReplaceNode(
                oldNode: namespaceNode,
                newNode: CreateNameSpaceSyntax(new SyntaxList<AttributeListSyntax>(),new SyntaxTokenList(),"yaju",new SyntaxList<ExternAliasDirectiveSyntax>(),new SyntaxList<UsingDirectiveSyntax>(),new SyntaxList<MemberDeclarationSyntax>()));
            Console.WriteLine(newnode.NormalizeWhitespace());
            return 0;
        }
    }
}