using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NodeAyano.Model.Nodes.Sentences
{
    public enum ConditionParamTypeEnum
    {
        Equals,
        GreaterThan,
        LessThan,
        LessThanOrEqual,
        GreaterThanOrEqual,
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
