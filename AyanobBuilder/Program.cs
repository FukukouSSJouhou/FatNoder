﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NodeAyano;
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
                Console.WriteLine("[Node  - Type: {0}, Kind: {1}]\n{2}\n", node.GetType().Name, node.Kind(), node);

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
        static NamespaceDeclarationSyntax CreateNameSpaceSyntax(string namekun,SyntaxList<MemberDeclarationSyntax> members)
        {
            var namesyntax = SyntaxFactory.IdentifierName(namekun);
            return SyntaxFactory.NamespaceDeclaration(new SyntaxList<AttributeListSyntax>(), new SyntaxTokenList(), namesyntax, new SyntaxList<ExternAliasDirectiveSyntax>(), new SyntaxList<UsingDirectiveSyntax>(),members);
        }
        static ClassDeclarationSyntax GenClass(string name)
        {
            return SyntaxFactory.ClassDeclaration(name);
        }
        /// <summary>
        /// Main Method
        /// </summary>
        /// <param name="args">Arguments</param>
        /// <returns>Status Code</returns>
        public static int Main(string[] args)
        {
            
            /*var sourceCode = @"
using System;
namespace tintin{
    class tinpo{
    static int Main(){
        int tdn=9;
        string tdn33=tdnx445;
        Console.WriteLine(tdn33);
        return tdn;
    }
    }
}";
            sourceCode = sourceCode.Replace("tdnx445", "\"tdn910\"");
            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
            var rootNode = syntaxTree.GetRoot();
            new Walker().Visit(rootNode);*/
            /*
            //Console.ReadKey();
            ClassDeclarationSyntax scls = GenClass("test21");
            SyntaxList<MemberDeclarationSyntax> Listkun;
            List<MemberDeclarationSyntax> lskun2 = new();
            var namespaceNode = rootNode.DescendantNodes().First(node => node.GetType() == typeof(NamespaceDeclarationSyntax));
            var namespaceSyntaxkun = namespaceNode.DescendantNodes().First(node => node.GetType() == typeof(IdentifierNameSyntax));
            var namespaceNode2 = namespaceNode.ReplaceNode(
                oldNode: namespaceSyntaxkun,
                newNode: SyntaxFactory.IdentifierName("tadokoro"))
                ;
            var newnode = rootNode.ReplaceNode(
                oldNode: namespaceNode,
                newNode: namespaceNode2);
            //Console.WriteLine(newnode.NormalizeWhitespace());*/
            var compilerstr = NodeAyanoCompiler.TransCompile(null);
            Console.WriteLine(compilerstr);
            /*var syntaxTree2 = CSharpSyntaxTree.ParseText(compilerstr);
            var rootNode2 = syntaxTree2.GetRoot();
            new Walker().Visit(rootNode2);*/
            return 0;
        }
    }
}