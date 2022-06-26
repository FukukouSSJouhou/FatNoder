using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.Serializer.Node.Xml
{
    /// <summary>
    /// XML Input Connect
    /// </summary>

    [DataContract(Name = "Connect")]
    public class XMLNodeInputConnect
    {
        /// <summary>
        /// Target Name
        /// </summary>
        [DataMember(Name = "Name", Order = 1)]
        public string Name
        {
            get; set;
        }
        /// <summary>
        /// Target
        /// </summary>
        [DataMember(Name = "Target", Order = 2)]
        public Guid Target
        {
            get; set;
        }
        public bool InputOnly
        {
            get;set;
        }
    }

    /// <summary>
    /// Output Connections
    /// </summary>
    [CollectionDataContract(Name = "connections")]
    public class XMLNodeInputConnectS : List<XMLNodeInputConnect>
    {

    }
    /// <summary>
    /// Node Output
    /// </summary>
    [DataContract(Name = "in")]
    public class XMLNodeInput
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
        public XMLNodeInputConnectS connections
        {
            get; set;
        }
    }
}
