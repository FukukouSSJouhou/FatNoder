using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NodeAyano.Model.Nodes
{
    /// <summary>
    /// Set value Node Model
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    public class SetValueNodeModel<T> : VariableDeclarationCompileNodeBase
    {
        /// <summary>
        /// Value
        /// </summary>
        [DataMember(Name = "Value", Order = 8)]

        public T Value
        {
            get; set;
        }
        /// <summary>
        /// Value Name
        /// </summary>
        [DataMember(Name = "ValueName", Order = 9)]

        public string ValueName
        {
            get; set;
        }

        /// <inheritdoc/>
        public override StatementSyntax[] CompileSyntax(IEnumerable<XML_NodeModel> xnodes)
        {
            List<StatementSyntax> returnstatements = new();

            foreach (XMLNodeInput xnode in Inputs)
            {
                if (xnode.Name == "Value")
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
                                if (typeof(T) == typeof(int))
                                {

                                    PredefinedTypeSyntax predeftype = SyntaxFactory.PredefinedType(SyntaxFactory.ParseToken("int"));
                                    List<VariableDeclaratorSyntax> vardecatorsynlist = new();
                                    VariableDeclarationSyntax valdeckun = SyntaxFactory.VariableDeclaration(predeftype);
                                    {
                                        VariableDeclaratorSyntax decr = SyntaxFactory.VariableDeclarator(ValueName);
                                        decr = decr.WithInitializer(
                                            SyntaxFactory.EqualsValueClause(
                                                    ((ValueCompileNodeBase)modelkun).CompileSyntax(xnodes))
                                            );
                                        vardecatorsynlist.Add(decr);
                                    }
                                    valdeckun = valdeckun.AddVariables(vardecatorsynlist.ToArray());
                                    LocalDeclarationStatementSyntax localdec = SyntaxFactory.LocalDeclarationStatement(valdeckun);
                                    returnstatements.Add(localdec);
                                }else if (typeof(T) == typeof(string))
                                {

                                    PredefinedTypeSyntax predeftype = SyntaxFactory.PredefinedType(SyntaxFactory.ParseToken("string"));
                                    List<VariableDeclaratorSyntax> vardecatorsynlist = new();
                                    VariableDeclarationSyntax valdeckun = SyntaxFactory.VariableDeclaration(predeftype);
                                    {
                                        VariableDeclaratorSyntax decr = SyntaxFactory.VariableDeclarator(ValueName);
                                        decr = decr.WithInitializer(
                                            SyntaxFactory.EqualsValueClause(
                                                    ((ValueCompileNodeBase)modelkun).CompileSyntax(xnodes))
                                            );
                                        vardecatorsynlist.Add(decr);
                                    }
                                    valdeckun = valdeckun.AddVariables(vardecatorsynlist.ToArray());
                                    LocalDeclarationStatementSyntax localdec = SyntaxFactory.LocalDeclarationStatement(valdeckun);
                                    returnstatements.Add(localdec);
                                }
                            }
                        }
                    }
                }
            }
            return returnstatements.ToArray();
        }
        /// <inheritdoc/>
        public override VariableDeclarationSyntax CompileSyntax_Variable(IEnumerable<XML_NodeModel> xnodes)
        {
            VariableDeclarationSyntax returnsyntax = null;
            foreach (XMLNodeInput xnode in Inputs)
            {
                if (xnode.Name == "Value")
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
                                if (typeof(T) == typeof(int))
                                {

                                    PredefinedTypeSyntax predeftype = SyntaxFactory.PredefinedType(SyntaxFactory.ParseToken("int"));
                                    List<VariableDeclaratorSyntax> vardecatorsynlist = new();
                                    VariableDeclarationSyntax valdeckun = SyntaxFactory.VariableDeclaration(predeftype);
                                    {
                                        VariableDeclaratorSyntax decr = SyntaxFactory.VariableDeclarator(ValueName);
                                        decr = decr.WithInitializer(
                                            SyntaxFactory.EqualsValueClause(
                                                    ((ValueCompileNodeBase)modelkun).CompileSyntax(xnodes))
                                            );
                                        vardecatorsynlist.Add(decr);
                                    }
                                    valdeckun = valdeckun.AddVariables(vardecatorsynlist.ToArray());
                                    returnsyntax = valdeckun;
                                }
                                else if (typeof(T) == typeof(string))
                                {

                                    PredefinedTypeSyntax predeftype = SyntaxFactory.PredefinedType(SyntaxFactory.ParseToken("string"));
                                    List<VariableDeclaratorSyntax> vardecatorsynlist = new();
                                    VariableDeclarationSyntax valdeckun = SyntaxFactory.VariableDeclaration(predeftype);
                                    {
                                        VariableDeclaratorSyntax decr = SyntaxFactory.VariableDeclarator(ValueName);
                                        decr = decr.WithInitializer(
                                            SyntaxFactory.EqualsValueClause(
                                                    ((ValueCompileNodeBase)modelkun).CompileSyntax(xnodes))
                                            );
                                        vardecatorsynlist.Add(decr);
                                    }
                                    valdeckun = valdeckun.AddVariables(vardecatorsynlist.ToArray());
                                    LocalDeclarationStatementSyntax localdec = SyntaxFactory.LocalDeclarationStatement(valdeckun);

                                    returnsyntax = valdeckun;
                                }
                            }
                        }
                    }
                }
            }
            return returnsyntax;
        }
    }
}
