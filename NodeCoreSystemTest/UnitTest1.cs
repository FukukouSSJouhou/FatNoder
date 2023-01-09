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
            Assert.AreEqual(1, 1);
        }
        [TestCase]
        public void PrintNodeTest()
        {
            Assert.AreEqual(1, 1);
        }


    }
}