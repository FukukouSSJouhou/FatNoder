﻿using FatXMLCore.Serializer.Node.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.Serializer.Node.Xml
{
    /// <summary>
    /// Xml Root Element
    /// </summary>
    [DataContract(Name = "root")]
    public class XmlRootN
    {
        /// <summary>
        /// dependencies
        /// </summary>
        [DataMember(Name ="dependencies")]
        public XMLRoot_DependsCLskun dependencies
        {
            get;set;
        }
        /// <summary>
        /// Nodes
        /// </summary>
        [DataMember(Name = "nodes")]
        public XMLRoot_NodesCLskun nodes
        {
            get;set;
        }
    }
    /// <summary>
    /// Nodes
    /// </summary>
    [CollectionDataContract(Name = "nodes", ItemName = "Node")]
    public class XMLRoot_NodesCLskun : List<XML_NodeModel>
    {

    }
    /// <summary>
    /// dependencies
    /// </summary>
    [CollectionDataContract(Name = "dependencies", ItemName = "dependency")]
    public class XMLRoot_DependsCLskun:List<XML_DEPEND>
    {

    }
}
