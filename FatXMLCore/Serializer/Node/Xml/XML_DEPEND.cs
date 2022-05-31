using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        private FileVersionInfo _minver;
        public string MinVersion
        {
            get
            {
                return _minver.ToString();
            }
            set
            {
                _minver = FileVersionInfo.GetVersionInfo(value);
            }
        }
        [IgnoreDataMember]
        public FileVersionInfo MinVersion_Fileinfo
        {
            get
            {
                return _minver;
            }
            set
            {
                _minver = value;
            }
        }

    }
}
