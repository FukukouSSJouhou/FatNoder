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
    public class MethodEntryPoint : XML_NodeModel
    {
        [DataMember(Name = "Name", Order = 1)]
        public string Name
        {
            get; set;
        }
        [DataMember(Name = "UUID", Order = 2)]
        public Guid UUID
        {
            get; set;
        }
        [DataMember(Name = "type", Order = 3)]
        public string TYPE
        {
            get; set;
        }
        [DataMember(Name = "InputStates", Order = 4, IsRequired = false)]
        public XMLNodeInputStatement_VMLS InputStates
        {
            get; set;
        }
        [DataMember(Name = "Outputs", Order = 5)]
        public XMLNodeOutputS Outputs
        {
            get; set;
        }
        [DataMember(Name = "Point", Order = 6)]
        public XMLNodeXY Points
        {
            get; set;
        }
    }
}
