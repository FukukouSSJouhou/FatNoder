using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NodeAyano.Model.Nodes.Sentences
{
    /// <summary>
    /// Condition Type Enum
    /// </summary>
    public enum ConditionParamTypeEnum
    {
        /// <summary>
        /// Equals
        /// </summary>
        [EnumMember]
        Equals,
        /// <summary>
        /// GreaterThan
        /// </summary>
        [EnumMember]
        GreaterThan,
        /// <summary>
        /// LessThan
        /// </summary>
        [EnumMember]
        LessThan,
        /// <summary>
        /// LessThanOrEqual
        /// </summary>
        [EnumMember]
        LessThanOrEqual,
        /// <summary>
        /// GreaterThanOrEqual
        /// </summary>
        [EnumMember]
        GreaterThanOrEqual,
        /// <summary>
        /// NotEquals
        /// </summary>
        [EnumMember]
        NotEquals
    }
    public class ConditionNodeModel: ValueCompileNodeBase
    {

        [DataMember(Name = "Value", Order = 8)]
        public string Value
        {
            get; set;
        }
        public ConditionParamTypeEnum ConditionType
        {
            get;set;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        public ConditionNodeModel()
        {
            ConditionType = ConditionParamTypeEnum.Equals;
        }
        
    }
}
