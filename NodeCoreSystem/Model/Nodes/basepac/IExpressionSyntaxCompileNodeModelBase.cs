using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyano.Model.Nodes.basepac
{
    /// <summary>
    /// ExpressionSyntax Compile Node Interface
    /// </summary>
    public interface IExpressionSyntaxCompileNodeModelBase
    {

        /// <summary>
        /// コンパイラメソッド(変数???用)
        /// </summary>
        /// <param name="xnodes">xnodes</param>
        /// <returns>ExpressionSyntax</returns>
        public abstract ExpressionSyntax CompileSyntax_ExpressionS(IEnumerable<XML_NodeModel> xnodes);
    }
}
