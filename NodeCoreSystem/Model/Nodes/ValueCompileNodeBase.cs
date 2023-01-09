using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyano.Model.Nodes
{
    /// <summary>
    /// For Value
    /// </summary>
    public abstract class ValueCompileNodeBase : XML_NodeModel
    {
        /// <summary>
        /// コンパイラメソッド
        /// </summary>
        /// <param name="xnodes">node list</param>
        /// <returns>メンバー君</returns>
        public abstract ExpressionSyntax CompileSyntax(IEnumerable<XML_NodeModel> xnodes);

    }
}
