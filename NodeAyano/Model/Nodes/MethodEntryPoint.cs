using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyano.Model.Nodes
{
    /// <summary>
    /// EntryPoint Model
    /// </summary>
    public class MethodEntryPoint : XML_NodeModel, IMethodPointBase
    {
        private static readonly string returntypename = "int";
        public MethodDeclarationSyntax CompileMethodSyntax()
        {
            MethodDeclarationSyntax methodkun = SyntaxFactory.MethodDeclaration(SyntaxFactory.ParseTypeName(returntypename), SyntaxFactory.Identifier(this.Name));
            
            return methodkun;
        }
    }
}
