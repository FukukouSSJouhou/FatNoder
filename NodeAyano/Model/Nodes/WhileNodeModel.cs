﻿using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyano.Model.Nodes
{
    public class WhileNodeModel : CompileNodeBase
    {
        [DataMember(Name = "Value", Order = 8)]
        public string Value
        {
            get; set;
        }
        /// <inheritdoc/>
        public override StatementSyntax[] CompileSyntax(IEnumerable<XML_NodeModel> xnodes)
        {
            ValueCompileNodeBase input1 = null;
            foreach (XMLNodeInput xnode in Inputs)
            {
                if (xnode.Name == "Condition")
                {
                    foreach (XMLNodeInputConnect cn in xnode.connections)
                    {
                        foreach (XML_NodeModel modelkun in xnodes.Where(
                            d =>
                            {
                                return d.UUID == cn.Target;
                            }))
                        {
                            if (modelkun is ValueCompileNodeBase)
                            {
                                input1 = (ValueCompileNodeBase)modelkun;
                            }
                        }
                    }
                }
            }
            List<StatementSyntax> returnstatements = new();
            BlockSyntax bsy = SyntaxFactory.Block(new List<StatementSyntax>());
            foreach (XMLNodeInputStatement st in InputStates)
            {
                if (st.Name == "Then")
                {
                    foreach (Guid cnUUID in st.States)
                    {
                        foreach (XML_NodeModel modelkun in xnodes.Where(
                            d =>
                            {
                                return d.UUID == cnUUID;
                            }))
                        {
                            if (modelkun is CompileNodeBase)
                            {
                                bsy = SyntaxFactory.Block(((CompileNodeBase)modelkun).CompileSyntax(xnodes));
                            }
                        }
                    }
                }
            }
            if(input1!=null)
            returnstatements.Add(SyntaxFactory.WhileStatement(
                input1.CompileSyntax(xnodes),
                bsy));
            return returnstatements.ToArray();
        }
    }
    
}
