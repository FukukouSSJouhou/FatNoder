using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyano.Model.Nodes
{
    /// <summary>
    /// 入力ノードのModel
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class InputNodeModel<T>: CompileNodeBase
    {

        [DataMember(Name="Value",Order=8)]
        public T Value
        {
            get;set;
        }

        public override StatementSyntax CompileSyntax()
        {
            throw new NotImplementedException();
        }
    }
}
