using FatNoder.Serializer.Node.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.Model
{
    /// <summary>
    /// XML Save Model
    /// </summary>
    public class SaveFileModel
    {
        /// <summary>
        /// Save File Request Class
        /// </summary>
        public class SaveFileRequest
        {
            /// <summary>
            /// XML File Name
            /// </summary>
            public string FilePath { get; set; }
            /// <summary>
            /// XML Serializer 
            /// </summary>
            public DataContractSerializer Serializer { get; set; }
            /// <summary>
            /// XML ROOT 
            /// </summary>
            public XmlRootN RootXML { get; set; }
        }
        /// <summary>
        /// Save File Response
        /// </summary>
        public class SaveFileResponse
        {
            /// <summary>
            /// Succeed??
            /// </summary>
            public bool IsSucceed { get; set; }
            /// <summary>
            /// Save MSG
            /// </summary>
            public string Message { get; set; }
        }

    }
}
