using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NodeAyano.Model.Nodes.ValueEnzann
{
    [DataContract]
    public enum ValueEnzannEngineType
    {
        [EnumMember]
        Add,
        [EnumMember]
        Divide,
        [EnumMember]
        Multiply,
        [EnumMember]
        Subract
    }
    public class ValueEnzannEngineNodeModel : ValueCompileNodeBase
    {


        [DataMember(Name = "Value", Order = 8)]

        public string Value
        {
            get; set;
        }
        [DataMember]
    }
}
