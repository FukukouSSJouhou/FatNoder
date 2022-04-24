using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.Serializer.Node.Xml
{
    [DataContract(Name = "NodeVM")]
    public class XML_NodeViewModel
    {
        [DataMember(Name = "Name", Order = 1)]
        public string Name
        {
            get;set;
        }
        [DataMember(Name = "UUID", Order = 2)]
        public string UUID
        {
            get;set;
        }
        [DataMember(Name = "Type", Order = 3)]
        public string TYPE
        {
            get;set;
        }

    }
}
