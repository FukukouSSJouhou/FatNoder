using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyano.Model.Nodes
{
    public abstract class CompileNodeBase: XML_NodeModel
    {
        /// <summary>
        /// コンパイラメソッド
        /// </summary>
        /// <returns>メンバー君</returns>
        public abstract StatementSyntax CompileSyntax();

    }
}
