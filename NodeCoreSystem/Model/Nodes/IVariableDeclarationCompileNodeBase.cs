using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeCoreSystem.Model.Nodes
{
    /// <summary>
    /// 変数定義用interface
    /// </summary>
    public interface IVariableDeclarationCompileNodeBase
    {
        /// <summary>
        /// コンパイラメソッド(変数定義用)
        /// </summary>
        /// <param name="xnodes">xnodes</param>
        /// <returns>VariableDeclarationSyntax</returns>
        public abstract VariableDeclarationSyntax CompileSyntax_Variable(IEnumerable<XML_NodeModel> xnodes);
    }
}
