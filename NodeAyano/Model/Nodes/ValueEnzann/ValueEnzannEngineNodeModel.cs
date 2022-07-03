using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NodeAyano.Model.Nodes.ValueEnzann
{
    /// <summary>
    /// Calc Type Enum
    /// </summary>
    [DataContract]
    public enum ValueEnzannEngineType
    {
        /// <summary>
        /// Add
        /// </summary>
        [EnumMember]
        Add,
        /// <summary>
        /// Divide
        /// </summary>
        [EnumMember]
        Divide,
        /// <summary>
        /// Multiply
        /// </summary>
        [EnumMember]
        Multiply,
        /// <summary>
        /// Subtract
        /// </summary>
        [EnumMember]
        Subtract
    }
    public class ValueEnzannEngineNodeModel : ValueCompileNodeBase
    {


        [DataMember(Name = "Value", Order = 8)]

        public string Value
        {
            get; set;
        }
        /// <summary>
        /// Calc Type
        /// </summary>
        [DataMember(Name="CalcType",Order =9)]
        public ValueEnzannEngineType CalcType
        {
            get;set;
        }
    }
}
