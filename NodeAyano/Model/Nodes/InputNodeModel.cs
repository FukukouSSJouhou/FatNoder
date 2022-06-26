using FatNoder.Serializer.Node.Xml;
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
    /// 入力ノードのModel
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class InputNodeModel<T> : CompileNodeBase
    {

        [DataMember(Name = "Value", Order = 8)]
        public T Value
        {
            get; set;
        }
/// <inheritdoc/>

        public override StatementSyntax[] CompileSyntax(IEnumerable<XML_NodeModel> xnodes)
        {
            List<StatementSyntax> statementskun222 = new();
            if (typeof(T) == typeof(int))
            {
                /*
                dynamic valuekundynamic = Value;
                foreach (XMLNodeOutput xnode in Outputs)
                {
                    if (xnode.Name == "Value")
                    {
                        foreach (XMLNodeOutputConnect cn in xnode.connections)
                        {
                            PredefinedTypeSyntax predeftype = SyntaxFactory.PredefinedType(SyntaxFactory.ParseToken("int"));
                            List<VariableDeclaratorSyntax> vardecatorsynlist = new();
                            VariableDeclarationSyntax valdeckun = SyntaxFactory.VariableDeclaration(predeftype);
                            {
                                VariableDeclaratorSyntax decr = SyntaxFactory.VariableDeclarator("id_" + cn.Target.ToString().Replace("-", "_") + "_" + cn.Name);
                                decr = decr.WithInitializer(
                                    SyntaxFactory.EqualsValueClause(SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(
                                        valuekundynamic)))
                                    );
                                vardecatorsynlist.Add(decr);
                            }
                            valdeckun = valdeckun.AddVariables(vardecatorsynlist.ToArray());
                            LocalDeclarationStatementSyntax localdec = SyntaxFactory.LocalDeclarationStatement(valdeckun);
                            statementskun222.Add(localdec);
                        }
                    }
                }*/
                dynamic valuekundynamic = Value;
                PredefinedTypeSyntax predeftype = SyntaxFactory.PredefinedType(SyntaxFactory.ParseToken("int"));
                List<VariableDeclaratorSyntax> vardecatorsynlist = new();
                VariableDeclarationSyntax valdeckun = SyntaxFactory.VariableDeclaration(predeftype);
                {
                    vardecatorsynlist.Add(SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(
                            valuekundynamic)));
                }
                valdeckun = valdeckun.AddVariables(vardecatorsynlist.ToArray());
                LocalDeclarationStatementSyntax localdec = SyntaxFactory.LocalDeclarationStatement(valdeckun);
                statementskun222.Add(localdec);

                return statementskun222.ToArray();
            }else if (typeof(T) == typeof(string))
            {

                dynamic valuekundynamic = Value;
                foreach (XMLNodeOutput xnode in Outputs)
                {
                    if (xnode.Name == "Value")
                    {
                        foreach (XMLNodeOutputConnect cn in xnode.connections)
                        {
                            PredefinedTypeSyntax predeftype = SyntaxFactory.PredefinedType(SyntaxFactory.ParseToken("string"));
                            List<VariableDeclaratorSyntax> vardecatorsynlist = new();
                            VariableDeclarationSyntax valdeckun = SyntaxFactory.VariableDeclaration(predeftype);
                            {
                                VariableDeclaratorSyntax decr = SyntaxFactory.VariableDeclarator("id_" + cn.Target.ToString().Replace("-", "_") + "_" + cn.Name);
                                decr = decr.WithInitializer(
                                    SyntaxFactory.EqualsValueClause(SyntaxFactory.LiteralExpression(SyntaxKind.StringLiteralExpression, SyntaxFactory.Literal(
                                        valuekundynamic)))
                                    );
                                vardecatorsynlist.Add(decr);
                            }
                            valdeckun = valdeckun.AddVariables(vardecatorsynlist.ToArray());
                            LocalDeclarationStatementSyntax localdec = SyntaxFactory.LocalDeclarationStatement(valdeckun);
                            statementskun222.Add(localdec);
                        }
                    }
                }
                return statementskun222.ToArray();
            }else if (typeof(T) == typeof(long))
            {

                dynamic valuekundynamic = Value;
                foreach (XMLNodeOutput xnode in Outputs)
                {
                    if (xnode.Name == "Value")
                    {
                        foreach (XMLNodeOutputConnect cn in xnode.connections)
                        {
                            PredefinedTypeSyntax predeftype = SyntaxFactory.PredefinedType(SyntaxFactory.ParseToken("long"));
                            List<VariableDeclaratorSyntax> vardecatorsynlist = new();
                            VariableDeclarationSyntax valdeckun = SyntaxFactory.VariableDeclaration(predeftype);
                            {
                                VariableDeclaratorSyntax decr = SyntaxFactory.VariableDeclarator("id_" + cn.Target.ToString().Replace("-", "_") + "_" + cn.Name);
                                decr = decr.WithInitializer(
                                    SyntaxFactory.EqualsValueClause(SyntaxFactory.LiteralExpression(SyntaxKind.NumericLiteralExpression, SyntaxFactory.Literal(
                                        valuekundynamic)))
                                    );
                                vardecatorsynlist.Add(decr);
                            }
                            valdeckun = valdeckun.AddVariables(vardecatorsynlist.ToArray());
                            LocalDeclarationStatementSyntax localdec = SyntaxFactory.LocalDeclarationStatement(valdeckun);
                            statementskun222.Add(localdec);
                        }
                    }
                }
                return statementskun222.ToArray();
            }
            statementskun222.Add(SyntaxFactory.Block());
            return statementskun222.ToArray();

        }
    }
}
