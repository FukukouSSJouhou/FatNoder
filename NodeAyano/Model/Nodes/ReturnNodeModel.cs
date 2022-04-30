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
        [DataMember(Name = "isconnected", Order =9)]
        public bool Isconnected
        {
            get; set;
        }

        public override StatementSyntax[] CompileSyntax()
        {
            List<StatementSyntax> statementskun65656565 = new();
            if (!Isconnected) { 
                if(typeof(T) == typeof(int))
                {

                    dynamic valuekundynamic = Value;
                    PredefinedTypeSyntax predeftype = SyntaxFactory.PredefinedType(SyntaxFactory.ParseToken("int"));
                    List<VariableDeclaratorSyntax> vardecatorsynlist = new();
                    VariableDeclarationSyntax valdeckun = SyntaxFactory.VariableDeclaration(predeftype);
                    {
                        VariableDeclaratorSyntax decr = SyntaxFactory.VariableDeclarator("id_" + UUID.ToString().Replace("-", "_") + "_ValueRet");
                        decr = decr.WithInitializer(
                            SyntaxFactory.EqualsValueClause(SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(
                                valuekundynamic)))
                            );
                        vardecatorsynlist.Add(decr);
                    }
                    valdeckun = valdeckun.AddVariables(vardecatorsynlist.ToArray());
                    LocalDeclarationStatementSyntax localdec = SyntaxFactory.LocalDeclarationStatement(valdeckun);
                    statementskun65656565.Add(localdec);
                }
                else
                {
                    return new StatementSyntax[1] { SyntaxFactory.Block() };
                }
            }
            ReturnStatementSyntax retstatement = SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName("id_" + this.UUID.ToString().Replace("-", "_") + "_ValueRet"));
            statementskun65656565.Add(retstatement);
            return statementskun65656565.ToArray() ;
        }
    }
}
