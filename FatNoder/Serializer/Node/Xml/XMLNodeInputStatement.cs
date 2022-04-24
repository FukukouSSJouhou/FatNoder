using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.Serializer.Node.Xml
{
    [CollectionDataContract(Name = "States")]
    public class XMLNodeInputStatementLS : List<string>
    {

    }
    [DataContract(Name = "Statement")]
    public class XMLNodeInputStatement
    {

        [DataMember(Name = "Name", Order = 1)]
        public string Name
        {
            get; set;
        }

        [DataMember(Name = "States", Order =2)]
        public XMLNodeInputStatementLS States
        {
            get;set;
        }

    }
}
