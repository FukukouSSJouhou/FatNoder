using FatNoder.Serializer.Node.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.Model
{
    public class SaveFileModel
    {
        public class SaveFileRequest
        {
            public string FilePath { get; set; }
            public DataContractSerializer Serializer { get; set; }
            public XmlRootN RootXML { get; set; }
        }
    }
}
