using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.Serializer.Node.Xml
{

    [DataContract(Name = "Connect")]
    public class XMLNodeOutputConnect
    {
        [DataMember(Name = "Name", Order = 1)]
        public string Name
        {
            get;set;
        }
        [DataMember(Name = "Target", Order = 2)]
        public Guid Target
        {
            get;set;
        }
    }

    [CollectionDataContract(Name = "connections")]
    public class XMLNodeOutputConnectS : List<XMLNodeOutputConnect>
    {

    }
    [DataContract(Name = "out")]
    public class XMLNodeOutput
    {
        [DataMember(Name = "Name", Order = 1)]
        public string Name
        {
            get; set;
        }
        [DataMember(Name = "connections", Order = 2)]
        public XMLNodeOutputConnectS connections
        {
            get; set;
        }
    }
}
