using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeCoreSystem.Model.Nodes
{
    public abstract class CompileNodeBase: XML_NodeModel
    {
        /// <summary>
        /// コンパイラメソッド
        /// </summary>
        /// <param name="xnodes">node list</param>
        /// <returns>メンバー君</returns>
        public abstract StatementSyntax[] CompileSyntax(IEnumerable<XML_NodeModel> xnodes);

    }
}
