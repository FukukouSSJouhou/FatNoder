using FatNoder.Serializer.Node.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyano.Model.Nodes
{

    [DataContract(Name = "Node")]
    public class InputNodeModel<T>: XML_NodeModel
    {
        [DataMember(Name="Value",Order=7)]
        public T Value
        {
            get;set;
        }
    }
}
