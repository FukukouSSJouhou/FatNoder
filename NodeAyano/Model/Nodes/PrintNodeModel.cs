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
    /// Print Node Model
    /// </summary>
    public class PrintNodeModel: CompileNodeBase
    {

        [DataMember(Name = "Value", Order = 8)]

        public string Value
        {
            get; set;
        }
        [DataMember(Name = "isconnected", Order = 9)]
        public bool Isconnected
        {
            get; set;
        }

        public override StatementSyntax[] CompileSyntax()
        {
            throw new NotImplementedException();
        }
    }
}
