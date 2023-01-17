using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NodeAyano.Model.Enumerator;
using NodeAyano.Model.Nodes.basepac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyano.Model.Nodes
{
    public class ForNodeModel : CompileNodeBase
    {
        [DataMember(Name = "Value", Order = 8)]
        public string Value
        {
            get; set;
        }
        /// <inheritdoc/>
        public override StatementSyntax[] CompileSyntax(IEnumerable<XML_NodeModel> xnodes)
        {
            VariableDeclarationSyntax input1 = null;
            ExpressionSyntax[] input1_initls = null;
            ValueCompileNodeBase input2 = null;
            VariableDeclarationSyntax incrsyn = null;
            ExpressionSyntax[] incrsyntaxls = null;
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
                                input2 = (ValueCompileNodeBase)modelkun;
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
                }
            }
            foreach (XMLNodeInputStatement st in InputStates)
            {
                if (st.Name == "Define")
                {
                    foreach (Guid cnUUID in st.States)
                    {
                        foreach (XML_NodeModel modelkun in xnodes.Where(
                            d =>
                            {
                                return d.UUID == cnUUID;
                            }))
                        {
                            if (modelkun is IVariableDeclarationCompileNodeBase)
                            {
                                input1 = ((IVariableDeclarationCompileNodeBase)modelkun).CompileSyntax_Variable(xnodes);
                            }
                            else if (modelkun is IExpressionSyntaxCompileNodeModelBase)
                            {
                                //input1 = ((IVariableDeclarationCompileNodeBase)modelkun).CompileSyntax_Variable(xnodes);
                                input1_initls = new[] {((IExpressionSyntaxCompileNodeModelBase)modelkun).CompileSyntax_ExpressionS(xnodes)};
                            }
                        }
                    }
                }
            }
            foreach (XMLNodeInputStatement st in InputStates)
            {
                if (st.Name == "Incr")
                {
                    foreach (Guid cnUUID in st.States)
                    {
                        foreach (XML_NodeModel modelkun in xnodes.Where(
                            d =>
                            {
                                return d.UUID == cnUUID;
                            }))
                        {
                            if (modelkun is IExpressionSyntaxCompileNodeModelBase)
                            {
                                //input1 = ((IVariableDeclarationCompileNodeBase)modelkun).CompileSyntax_Variable(xnodes);
                                incrsyntaxls = new[] { ((IExpressionSyntaxCompileNodeModelBase)modelkun).CompileSyntax_ExpressionS(xnodes) };
                            }
                        }
                    }
                }
            }
            if (input1 != null)
            {
                if (input2 != null)
                {
                    if(incrsyntaxls!=null)
                    returnstatements.Add(SyntaxFactory.ForStatement(input1, SyntaxFactory.SeparatedList<ExpressionSyntax>(), input2.CompileSyntax(xnodes), SyntaxFactory.SeparatedList<ExpressionSyntax>(incrsyntaxls), bsy));
                }
            }else if(input1_initls != null)
            {
                if (input2 != null)
                {
                    if (incrsyntaxls != null)
                        returnstatements.Add(SyntaxFactory.ForStatement(null, SyntaxFactory.SeparatedList<ExpressionSyntax>(input1_initls), input2.CompileSyntax(xnodes), SyntaxFactory.SeparatedList<ExpressionSyntax>(incrsyntaxls), bsy));
                }
            }
            return returnstatements.ToArray();
        }                    
    }
}
