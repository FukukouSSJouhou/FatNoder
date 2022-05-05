using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.Serializer.Node.Xml
{
    /// <summary>
    /// XML Output Connect
    /// </summary>

    [DataContract(Name = "Connect")]
    public class XMLNodeOutputConnect
    {
        /// <summary>
        /// Target Name
        /// </summary>
        [DataMember(Name = "Name", Order = 1)]
        public string Name
        {
            get;set;
        }
        /// <summary>
        /// Target
        /// </summary>
        [DataMember(Name = "Target", Order = 2)]
        public Guid Target
        {
            get;set;
        }
    }

    /// <summary>
    /// Output Connections
    /// </summary>
    [CollectionDataContract(Name = "connections")]
    public class XMLNodeOutputConnectS : List<XMLNodeOutputConnect>
    {

    }
    /// <summary>
    /// Node Output
    /// </summary>
    [DataContract(Name = "out")]
    public class XMLNodeOutput
    {
        /// <summary>
        /// Name
        /// </summary>
        [DataMember(Name = "Name", Order = 1)]
        public string Name
        {
            get; set;
        }
        /// <summary>
        /// Node Connections
        /// </summary>
        [DataMember(Name = "connections", Order = 2)]
        public XMLNodeOutputConnectS connections
        {
            get; set;
        }
    }
}
