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

namespace NodeAyano.Model.Nodes.ValueEnzann
{
    public class AddNodeModel : ValueCompileNodeBase
    {

        [DataMember(Name = "Value", Order = 8)]

        public string Value
        {
            get; set;
        }

        /// <inheritdoc/>

        public override ExpressionSyntax CompileSyntax(IEnumerable<XML_NodeModel> xnodes)
        {
            ValueCompileNodeBase input1 = null;
            ValueCompileNodeBase input2 = null;
            foreach (XMLNodeInput xnode in Inputs)
            {
                if (xnode.Name == "Input1")
                {

                    foreach (XMLNodeInputConnect cn in xnode.connections)
                    {
                        foreach (XML_NodeModel modelkun in xnodes.Where(
                            d =>
                            {
                                return d.UUID == cn.Target;
                            }))
                        {
                            if (modelkun is ValueCompileNodeBase)
                            {
                                input1 = (ValueCompileNodeBase)modelkun;

                            }
                        }
                    }
                }
                else if (xnode.Name == "Input2")
                {

                    foreach (XMLNodeInputConnect cn in xnode.connections)
                    {
                        foreach (XML_NodeModel modelkun in xnodes.Where(
                            d =>
                            {
                                return d.UUID == cn.Target;
                            }))
                        {
                            if (modelkun is ValueCompileNodeBase)
                            {
                                input2 = (ValueCompileNodeBase)modelkun;

                            }
                        }
                    }
                }
            }
            if (input1 != null && input2 != null)
            {
                return SyntaxFactory.BinaryExpression(SyntaxKind.AddExpression, input1.CompileSyntax(xnodes), input2.CompileSyntax(xnodes));
            }
            else
            {
                return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(
                                        0));
            }
        }
    }
}
