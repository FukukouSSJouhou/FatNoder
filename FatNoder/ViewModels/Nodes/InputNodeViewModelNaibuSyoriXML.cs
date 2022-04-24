using FatNoder.Serializer.Node.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels.Nodes
{

    [DataContract(Name = "Datas")]
    public class InputNodeViewModelNaibuSyoriXML : XmlNodeDatas
    {
        [DataMember(Name = "Value", Order = 1)]
        public string Value
        {
            get; set;
        }
    }
}
