using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp;
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
    /// ReturnNode Model
    /// </summary>
    /// <typeparam name="T">Type!</typeparam>
    public class ReturnNodeModel<T> : CompileNodeBase
    {
        [DataMember(Name = "Value", Order = 8)]

        public T Value
        {
            get; set;
        }
        [DataMember(Name = "isconnected", Order =9)]
        public bool Isconnected
        {
            get; set;
        }

        public override StatementSyntax CompileSyntax()
        {
            if (Isconnected)
            {

            }
            return SyntaxFactory.Block(); 
        }
    }
}
