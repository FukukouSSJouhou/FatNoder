﻿using FatNoder.Serializer.Node.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyano.Model.Nodes
{
    /// <summary>
    /// ReturnNode Model
    /// </summary>
    /// <typeparam name="T">Type!</typeparam>
    public class ReturnNodeModel<T> : XML_NodeModel
    {
        [DataMember(Name = "Value", Order = 8)]

        public T Value
        {
            get; set;
        }
    }
}
