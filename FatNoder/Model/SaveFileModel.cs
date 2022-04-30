using FatNoder.Serializer.Node.Xml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FatNoder.Model
{
    /// <summary>
    /// XML Save Model
    /// </summary>
    public class SaveFileModel
    {
        /// <summary>
        /// Save XML File 
        /// </summary>
        /// <param name="req">Request</param>
        /// <returns>Response</returns>
        public SaveFileResponse SaveXML(SaveFileRequest req)
        {
            SaveFileResponse resp = null;
            try
            {
                using (StreamWriter sw = new StreamWriter(req.FilePath, false))
                {

                    var settings = new XmlWriterSettings()
                    {
                        Indent = true,
                        IndentChars = "    ",
                        Encoding = new System.Text.UTF8Encoding(false)
                    };

                    using (var xw = XmlWriter.Create(sw, settings))
                    {
                        req.Serializer.WriteObject(xw, req.RootXML);
                    }
                }
                resp = new SaveFileResponse()
                {
                    IsSucceed = true,
                    Message = "XML saved successfully!"
                };
            }
            catch (Exception ex)
            {
                resp = new SaveFileResponse()
                {
                    IsSucceed = false,
                    Message = ex.Message
                };
            }
            return resp;
        }
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
