using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NodeAyano.Model.Nodes
{
    public class IfNodeModel : CompileNodeBase
    {

        [DataMember(Name = "Value", Order = 8)]

        public string Value
        {
            get; set;
        }

        /// <inheritdoc/>

        public override StatementSyntax[] CompileSyntax(IEnumerable<XML_NodeModel> xnodes)
        {

        }
    }
}
