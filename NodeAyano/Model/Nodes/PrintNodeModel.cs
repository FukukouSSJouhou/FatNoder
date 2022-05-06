﻿using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyano.Model.Nodes
{
    /// <summary>
    /// Print Node Model
    /// </summary>
    public class PrintNodeModel : CompileNodeBase
    {

        [DataMember(Name = "Value", Order = 8)]

        public string Value
        {
            get; set;
        }
        [DataMember(Name = "isconnected", Order = 9)]
        public bool Isconnected
        {
            get; set;
        }
        [DataMember(Name = "Value_Edit", Order = 10)]
        [DefaultValue("")]
        public string Value_Edit
        {
            get; set;
        }

        /// <inheritdoc/>
        public override StatementSyntax[] CompileSyntax()
        {
            List<StatementSyntax> returnstatements = new();

            if (!Isconnected)
            {
                dynamic valuekundynamic = Value;
                PredefinedTypeSyntax predeftype = SyntaxFactory.PredefinedType(SyntaxFactory.ParseToken("string"));
                List<VariableDeclaratorSyntax> vardecatorsynlist = new();
                VariableDeclarationSyntax valdeckun = SyntaxFactory.VariableDeclaration(predeftype);
                {
                    VariableDeclaratorSyntax decr = SyntaxFactory.VariableDeclarator("id_" + UUID.ToString().Replace("-", "_") + "_Printcontent");
                    decr = decr.WithInitializer(
                        SyntaxFactory.EqualsValueClause(SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(
                            valuekundynamic)))
                        );
                    vardecatorsynlist.Add(decr);
                }
                valdeckun = valdeckun.AddVariables(vardecatorsynlist.ToArray());
                LocalDeclarationStatementSyntax localdec = SyntaxFactory.LocalDeclarationStatement(valdeckun);
                returnstatements.Add(localdec);
            }

            returnstatements.Add(
                SyntaxFactory.ExpressionStatement(
                SyntaxFactory.InvocationExpression(
                    SyntaxFactory.MemberAccessExpression(
                            SyntaxKind.SimpleMemberAccessExpression,
                            SyntaxFactory.IdentifierName("Console"),
                            SyntaxFactory.IdentifierName("WriteLine")
                        ),
                    SyntaxFactory.ArgumentList(
                        SyntaxFactory.SeparatedList<ArgumentSyntax>(
                            new ArgumentSyntax[1]{SyntaxFactory.Argument(
                                SyntaxFactory.IdentifierName("id_" + UUID.ToString().Replace("-", "_") + "_Printcontent")
                            ) }

                    )
                ))));
            return returnstatements.ToArray();
        }
    }
}
