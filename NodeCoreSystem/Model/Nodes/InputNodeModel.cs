using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NodeCoreSystem.Model.Nodes
{
    /// <summary>
    /// 入力ノードのModel
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class InputNodeModel<T> : ValueCompileNodeBase
    {

        [DataMember(Name = "Value", Order = 8)]
        public T Value
        {
            get; set;
        }
        /// <inheritdoc/>

        public override LiteralExpressionSyntax CompileSyntax(IEnumerable<XML_NodeModel> xnodes)
        {
            //List<StatementSyntax> statementskun222 = new();
            if (typeof(T) == typeof(int))
            {
                dynamic valuekundynamic = Value;
                return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(
                            valuekundynamic));
            }
            else if (typeof(T) == typeof(string))
            {

                dynamic valuekundynamic = Value;
                return SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(
                                        valuekundynamic));
            }
            else if (typeof(T) == typeof(long))
            {

                dynamic valuekundynamic = Value;
                return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(
                            valuekundynamic));
            }
            dynamic valuekundynamic23 = 0;
            return SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(
                            valuekundynamic23));

        }
    }
}
