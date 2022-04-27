using FatNoder.Serializer.Node.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyano.Model.Nodes
{
    public class PrintNodeModel: XML_NodeModel
    {

        [DataMember(Name = "Value", Order = 7)]

        public string Value
        {
            get; set;
        }
    }
}
