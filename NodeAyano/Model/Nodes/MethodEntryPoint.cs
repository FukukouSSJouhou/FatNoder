﻿using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyano.Model.Nodes
{
    /// <summary>
    /// EntryPoint Model
    /// </summary>
    public class MethodEntryPoint : XML_NodeModel, IMethodPointBase
    {
        public MethodDeclarationSyntax CompileMethodSyntax()
        {
            throw new NotImplementedException();
        }
    }
}
