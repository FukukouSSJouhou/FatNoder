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
        [DataMember(Name = "Name", Order = 1)]
        public string Name { get; set; }
        private FileVersionInfo _minver;
        /// <summary>
        /// Min Version
        /// </summary>
        [DataMember(Name = "min", Order = 2)]
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
        /// <summary>
        /// Min Version FileVer
        /// </summary>
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
        /// <summary>
        /// Max version
        /// </summary>
        [DataMember(Name = "max", Order = 3)]
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
        /// <summary>
        /// Max version FileInfo
        /// </summary>
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
