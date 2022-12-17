using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;
using NodeAyano.Model.Nodes.basepac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NodeAyano.Model.Nodes.Http
{
    /// <summary>
    /// client node?
    /// </summary>
    public class HttpClientPostDataNodeModel : CompileNodeBase
    {

        [DataMember(Name = "Value", Order = 8)]

        public string Value
        {
            get; set;
        }
        /// <inheritdoc/>
        public override StatementSyntax[] CompileSyntax(IEnumerable<XML_NodeModel> xnodes)
        {
            List<StatementSyntax> returnstatements = new();

            BlockSyntax bsy = SyntaxFactory.Block(new List<StatementSyntax>());
            
            foreach (XMLNodeInput xnode in Inputs)
            {
                if (xnode.Name == "TargetURL")
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
                                /*
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
                                                    ((ValueCompileNodeBase)modelkun).CompileSyntax(xnodes)

                                                ) }

                                    )
                            ))));*/
                                
                            }
                        }
                    }
                }
            }

            returnstatements.Add(bsy);
            return returnstatements.ToArray();
        }
    }
}
