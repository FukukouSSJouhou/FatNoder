using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.VisualBasic;
using NodeAyano.Model.Nodes.ValueEnzann;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NodeAyano.Model.Nodes.Sentences
{
    /// <summary>
    /// Condition Type Enum
    /// </summary>
    [DataContract(Name = "ConditionType")]
    public enum ConditionParamTypeEnum
    {
        /// <summary>
        /// Equals
        /// </summary>
        [EnumMember]
        Equals,
        /// <summary>
        /// GreaterThan
        /// </summary>
        [EnumMember]
        GreaterThan,
        /// <summary>
        /// LessThan
        /// </summary>
        [EnumMember]
        LessThan,
        /// <summary>
        /// LessThanOrEqual
        /// </summary>
        [EnumMember]
        LessThanOrEqual,
        /// <summary>
        /// GreaterThanOrEqual
        /// </summary>
        [EnumMember]
        GreaterThanOrEqual,
        /// <summary>
        /// NotEquals
        /// </summary>
        [EnumMember]
        NotEquals
    }
    public class ConditionNodeModel: ValueCompileNodeBase
    {

        [DataMember(Name = "Value", Order = 8)]
        public string Value
        {
            get; set;
        }
        /// <summary>
        /// Condition Type
        /// </summary>
        [DataMember(Name= "ConditionType",Order =9)]
        public ConditionParamTypeEnum ConditionType
        {
            get;set;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public ConditionNodeModel()
        {
            ConditionType = ConditionParamTypeEnum.Equals;
        }
        ///<inheritdoc/>
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
                SyntaxKind kindkun;
                switch (ConditionType)
                {
                    case ConditionParamTypeEnum.Equals:
                        kindkun = SyntaxKind.EqualsExpression;
                        break;
                    case ConditionParamTypeEnum.NotEquals:
                        kindkun = SyntaxKind.NotEqualsExpression;
                        break;
                    case ConditionParamTypeEnum.GreaterThan:
                        kindkun = SyntaxKind.GreaterThanExpression;
                        break;
                    case ConditionParamTypeEnum.GreaterThanOrEqual:
                        kindkun = SyntaxKind.GreaterThanOrEqualExpression;
                        break;
                    case ConditionParamTypeEnum.LessThan:
                        kindkun = SyntaxKind.LessThanExpression;
                        break;
                    case ConditionParamTypeEnum.LessThanOrEqual:
                        kindkun = SyntaxKind.LessThanOrEqualExpression;
                        break;
                    default:
                        kindkun = SyntaxKind.EqualsExpression;
                        break;
                }
                return SyntaxFactory.BinaryExpression(kindkun, input1.CompileSyntax(xnodes), input2.CompileSyntax(xnodes));

            }
            else
            {
                return SyntaxFactory.LiteralExpression(SyntaxKind.TrueLiteralExpression);
            }
        }

    }
}
