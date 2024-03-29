﻿using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NodeAyano.Model.Enumerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NodeAyano.Model.Nodes
{
    public class IfNodeModel : CompileNodeBase
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
            BlockSyntax ElseSyntax = null;
            foreach(XMLNodeInputStatement st in InputStates)
            {
                if(st.Name == "Then")
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
                                NodeModelEnumerator enumkun = new NodeModelEnumerator(modelkun, xnodes);
                                enumkun.Reset();
                                var statements = new List<StatementSyntax>();
                                while (enumkun.MoveNext())
                                {

                                    if (enumkun.Current is CompileNodeBase)
                                    {
                                        foreach (StatementSyntax sckun in ((CompileNodeBase)enumkun.Current).CompileSyntax(xnodes))
                                        {
                                            statements.Add(sckun);
                                        }
                                    }
                                }
                                bsy = SyntaxFactory.Block(statements.ToArray());

                            }
                        }
                    }
                }else if(st.Name == "Else")
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
                                NodeModelEnumerator enumkun = new NodeModelEnumerator(modelkun, xnodes);
                                enumkun.Reset();
                                var statements = new List<StatementSyntax>();
                                while (enumkun.MoveNext())
                                {

                                    if (enumkun.Current is CompileNodeBase)
                                    {
                                        foreach (StatementSyntax sckun in ((CompileNodeBase)enumkun.Current).CompileSyntax(xnodes))
                                        {
                                            statements.Add(sckun);
                                        }
                                    }
                                }
                                ElseSyntax = SyntaxFactory.Block(statements.ToArray());

                            }
                        }
                    }
                }
            }
            if (input1 != null)
                if (ElseSyntax != null)
                {
                    returnstatements.Add(SyntaxFactory.IfStatement(input1.CompileSyntax(xnodes), bsy, SyntaxFactory.ElseClause(ElseSyntax)));
                }
                else
                {
                    returnstatements.Add(SyntaxFactory.IfStatement(input1.CompileSyntax(xnodes), bsy));
                }
            return returnstatements.ToArray();
        }
    }
}
