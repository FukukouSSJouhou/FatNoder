using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NodeAyano.Model.Nodes;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;

namespace NodeAyanoTest
{

    public class Tests
    {
        private static ClassDeclarationSyntax CreateClass(string name)
        {

            return SyntaxFactory.ClassDeclaration(name).AddModifiers(new SyntaxToken[1] { SyntaxFactory.Token(SyntaxKind.PublicKeyword) });
        }
        [SetUp]
        public void Setup()
        {
        }
        [TestCase]
        public void ReturnNodeTest()
        {

            var compUnit = SyntaxFactory.CompilationUnit();
            var CLSList = new List<MemberDeclarationSyntax>();
            var NSList = new List<MemberDeclarationSyntax>();
            var USList = new List<UsingDirectiveSyntax>();
            var SCLS = CreateClass("CLS");
            var nsNode = SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName("NS"));

            var newnode = compUnit;
            var SCLSMethodLists = new List<MemberDeclarationSyntax>();
            USList.Add(SyntaxFactory.UsingDirective(SyntaxFactory.IdentifierName("System")));
            MethodDeclarationSyntax methodkun = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName("int"), SyntaxFactory.Identifier("Metkun"));
            var statements = new List<StatementSyntax>();
            var returnM = new ReturnNodeModel<int>
            {
                Value = 1,
                Isconnected = false
            };
            statements.AddRange(returnM.CompileSyntax());
            methodkun = methodkun.AddBodyStatements(statements.ToArray());
            SCLSMethodLists.Add(methodkun);
            SCLS = SCLS.AddMembers(SCLSMethodLists.ToArray());
            CLSList.Add(SCLS);
            nsNode = nsNode.AddMembers(CLSList.ToArray());
            NSList.Add(nsNode);
            newnode = newnode.AddUsings(USList.ToArray());
            newnode = newnode.AddMembers(NSList.ToArray());

            Debug.Print(newnode.NormalizeWhitespace().ToString());
            Assert.True(true);
        }


    }
}