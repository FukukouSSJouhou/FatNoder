using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FatNoder.Serializer.Node.Xml
{
    /// <summary>
    /// XML Input Statements
    /// </summary>
    [CollectionDataContract(Name = "InputStates")]
    public class XMLNodeInputStatement_VMLS : List<XMLNodeInputStatement>
    {

    }
    /// <summary>
    /// XML Node Outputs
    /// </summary>
    [CollectionDataContract(Name="Outputs")]
    public class XMLNodeOutputS : List<XMLNodeOutput>
    {

    }
    /// <summary>
    /// XML Node Inputs
    /// </summary>
    [CollectionDataContract(Name = "Inputs")]
    public class XMLNodeInputS : List<XMLNodeInput>
    {

    }
    /// <summary>
    /// XML Node Point
    /// </summary>
    [DataContract(Name = "point")]
    public class XMLNodeXY
    {
        [DataMember(Name ="X")]

        public double X
        {
            get;set;
        }
        [DataMember(Name ="Y")]
        public double Y
        {
            get;set;
        }
    }
    /// <summary>
    /// XML Node!!
    /// </summary>
    [DataContract(Name = "Node")]
    public class XML_NodeModel
    {
        
        /// <summary>
        /// Node Name
        /// </summary>
        [DataMember(Name = "Name", Order = 1)]
        public string Name
        {
            get;set;
        }
        /// <summary>
        /// Node UUID
        /// </summary>
        [DataMember(Name = "UUID", Order = 2)]
        public Guid UUID
        {
            get;set;
        }
        /// <summary>
        /// Node Type(Type string)
        /// </summary>
        [DataMember(Name = "type",Order=3)]
        public string TYPE
        {
            get;set;
        }
        /// <summary>
        /// Node InputStates
        /// </summary>
        [DataMember(Name= "InputStates",Order=4,IsRequired =false)]
        public XMLNodeInputStatement_VMLS InputStates
        {
            get;set;
        }
        /// <summary>
        /// Node Outputs
        /// </summary>
        [DataMember(Name="Outputs",Order=5)]
        public XMLNodeOutputS Outputs
        {
            get;set;
        }
        /// <summary>
        /// Node Inputs
        /// </summary>
        [DataMember(Name = "Inputs", Order = 5)]
        public XMLNodeInputS Inputs
        {
            get; set;
        }
        /// <summary>
        /// Node Location
        /// </summary>
        [DataMember(Name = "Point", Order = 6)]
        public XMLNodeXY Points
        {
            get;set;
        }
        /// <summary>
        /// Node Model Type
        /// </summary>
        [DataMember(Name = "modeltype", Order = 7)]
        public string MODELTYPE
        {
            get; set;
        }


    }
}
