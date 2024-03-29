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
    /// <summary>
    /// ReturnNode Model
    /// </summary>
    /// <typeparam name="T">Type!</typeparam>
    public class ReturnNodeModel<T> : CompileNodeBase
    {
        [DataMember(Name = "ValueRet", Order = 8)]

        public T Value
        {
            get; set;
        }

        /// <inheritdoc/>
        public override StatementSyntax[] CompileSyntax(IEnumerable<XML_NodeModel> xnodes)
        {
            List<StatementSyntax> statementskun65656565 = new();
            foreach (XMLNodeInput xnode in Inputs)
            {
                if (xnode.Name == "ValueRet")
                {
                    foreach (XMLNodeInputConnect cn in xnode.connections)
                    {
                        foreach(XML_NodeModel modelkun in xnodes.Where(
                            d =>
                            {
                                return d.UUID == cn.Target;
                            }))
                        {
                            if(modelkun is ValueCompileNodeBase)
                            {

                                ReturnStatementSyntax retstatement = SyntaxFactory.ReturnStatement(((ValueCompileNodeBase)modelkun).CompileSyntax(xnodes));
                                statementskun65656565.Add(retstatement);
                                return statementskun65656565.ToArray();
                            }
                        }
                    }
                }
            }
                        //ReturnStatementSyntax retstatement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("id_" + this.UUID.ToString().Replace("-", "_") + "_ValueRet"));
           //statementskun65656565.Add(retstatement);
            return statementskun65656565.ToArray() ;
        }
    }
}
