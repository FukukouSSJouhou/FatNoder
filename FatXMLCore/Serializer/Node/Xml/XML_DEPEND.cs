using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FatXMLCore.Serializer.Node.Xml
{

    /// <summary>
    /// dependency
    /// </summary>
    [DataContract(Name = "dependency")]
    public class XML_DEPEND
    {
        public string name { get; set; }
    }
}
