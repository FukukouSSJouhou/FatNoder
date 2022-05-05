using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.Serializer.Node.Xml
{
    /// <summary>
    /// Node Statement GUID List
    /// </summary>
    [CollectionDataContract(Name = "States")]
    public class XMLNodeInputStatementLS : List<Guid>
    {

    }
    /// <summary>
    /// Input Statement XML Node
    /// </summary>
    [DataContract(Name = "Statement")]
    public class XMLNodeInputStatement
    {
        /// <summary>
        /// Node Name
        /// </summary>

        [DataMember(Name = "Name", Order = 1)]
        public string Name
        {
            get; set;
        }
        /// <summary>
        /// Node States
        /// </summary>
        [DataMember(Name = "States", Order =2)]
        public XMLNodeInputStatementLS States
        {
            get;set;
        }

    }
}
