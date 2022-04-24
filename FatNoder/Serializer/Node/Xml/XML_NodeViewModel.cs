using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FatNoder.Serializer.Node.Xml
{
    [CollectionDataContract(Name = "InputStates")]
    public class XMLNodeInputStatement_VMLS : List<XMLNodeInputStatement>
    {

    }
    [CollectionDataContract(Name="Outputs")]
    public class XMLNodeOutputS : List<XMLNodeOutput>
    {

    }
    [DataContract(Name = "NodeVM")]
    public class XML_NodeViewModel
    {
        
        [DataMember(Name = "Name", Order = 1)]
        public string Name
        {
            get;set;
        }
        [DataMember(Name = "UUID", Order = 2)]
        public string UUID
        {
            get;set;
        }
        [DataMember(Name = "type",Order=3)]
        public string TYPE
        {
            get;set;
        }
        [DataMember(Name= "InputStates",Order=4,IsRequired =false)]
        public XMLNodeInputStatement_VMLS InputStates
        {
            get;set;
        }
        [DataMember(Name="Outputs",Order=5)]
        public XMLNodeOutputS Outputs
        {
            get;set;
        }
        [DataMember(Name= "Datas",Order =6)]
        public XmlNodeDatas Datas
        {
            get;set;
        }
        [DataMember(Name = "datatype", Order =7)]
        public string DTTYPE
        {
            get; set;
        }

    }
}
