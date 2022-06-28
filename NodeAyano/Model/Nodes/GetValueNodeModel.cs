using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp;
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
    /// <summary>
    /// Get Value Node Model
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class GetValueNodeModel : ValueCompileNodeBase
    {

        /// <summary>
        /// Value Name
        /// </summary>
        [DataMember(Name = "ValueName", Order = 8)]

        public string ValueName
        {
            get; set;
        }
        ///<inheritdoc/>
        public override ExpressionSyntax CompileSyntax(IEnumerable<XML_NodeModel> xnodes)
        {
            return SyntaxFactory.IdentifierName(ValueName);

        }
    }
}
