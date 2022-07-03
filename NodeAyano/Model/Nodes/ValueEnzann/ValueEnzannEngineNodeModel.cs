using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NodeAyano.Model.Nodes.ValueEnzann
{
    /// <summary>
    /// Calc Type Enum
    /// </summary>
    [DataContract]
    public enum ValueEnzannEngineType
    {
        /// <summary>
        /// Add
        /// </summary>
        [EnumMember]
        Add,
        /// <summary>
        /// Divide
        /// </summary>
        [EnumMember]
        Divide,
        /// <summary>
        /// Multiply
        /// </summary>
        [EnumMember]
        Multiply,
        /// <summary>
        /// Subtract
        /// </summary>
        [EnumMember]
        Subtract,
        /// <summary>
        /// None
        /// </summary>
        [EnumMember]
        None
    }
    public class ValueEnzannEngineNodeModel : ValueCompileNodeBase
    {


        [DataMember(Name = "Value", Order = 8)]

        public string Value
        {
            get; set;
        }
        /// <summary>
        /// Calc Type
        /// </summary>
        [DataMember(Name="CalcType",Order =9)]
        public ValueEnzannEngineType CalcType
        {
            get;set;
        }
        public ValueEnzannEngineNodeModel()
        {
            CalcType = ValueEnzannEngineType.None;
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
                SyntaxKind ensankind = SyntaxKind.None;
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
