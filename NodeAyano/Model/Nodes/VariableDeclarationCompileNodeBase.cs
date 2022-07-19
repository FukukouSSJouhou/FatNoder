using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyano.Model.Nodes
{
    public abstract class VariableDeclarationCompileNodeBase : XML_NodeModel
    {
        
        public abstract VariableDeclarationSyntax CompileSyntax_Variable(IEnumerable<XML_NodeModel> xnodes);
    }
}
