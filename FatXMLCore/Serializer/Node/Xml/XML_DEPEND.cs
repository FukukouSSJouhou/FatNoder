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
        /// <summary>
        /// Name
        /// </summary>
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
        private FileVersionInfo _maxver;
        public string MaxVersion
        {
            get
            {
                return _maxver.ToString();
            }
            set
            {
                _maxver = FileVersionInfo.GetVersionInfo(value);
            }
        }
        [IgnoreDataMember]
        public FileVersionInfo MaxVersion_Fileinfo
        {
            get
            {
                return _maxver;
            }
            set
            {
                _maxver = value;
            }
        }

    }
}
