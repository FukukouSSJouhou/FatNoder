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
        [DataMember(Name = "Parent", Order = 2)]
        public string Parent
        {
            get;set;
        }
    }
    public class XMLNodeOutputConnectS : List<XMLNodeOutputConnect>
    {

    }
    public class XMLNodeOutput
    {
        public string Name
        {
            get;set;
        }
        public 
    }
}
