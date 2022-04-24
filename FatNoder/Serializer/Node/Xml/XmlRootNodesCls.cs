using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.Serializer.Node.Xml
{
    [DataContract(Name = "root")]
    public class XmlRootNodesCls
    {
        [CollectionDataContract(Name="nodes",ItemName ="NodeVM")]
        public class XMLRoot_NodesCLskun:List<XML_NodeViewModel>
        {

        }
    }
}
