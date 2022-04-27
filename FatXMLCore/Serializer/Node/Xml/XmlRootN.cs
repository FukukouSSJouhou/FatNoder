using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.Serializer.Node.Xml
{
    [DataContract(Name = "root")]
    public class XmlRootN
    {
        [DataMember(Name = "nodes")]
        public XMLRoot_NodesCLskun nodes
        {
            get;set;
        }
    }
    [CollectionDataContract(Name = "nodes", ItemName = "Node")]
    public class XMLRoot_NodesCLskun : List<XML_NodeModel>
    {

    }
}
