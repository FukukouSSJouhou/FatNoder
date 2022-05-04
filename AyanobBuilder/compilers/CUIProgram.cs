using AyanoBuilder.CUItools;
using FatNoder.Serializer.Node.Xml;
using Microsoft.Extensions.CommandLineUtils;
using NodeAyano;
using NodeAyano.Model.Enumerator;
using NodeAyano.Model.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AyanoBuilder.compilers
{
    /// <summary>
    /// Compiler CUI
    /// </summary>
    public class CUIProgram
    {
        /// <summary>
        /// Main CUI EntryPoint
        /// </summary>
        /// <param name="args">Arguments</param>
        /// <returns>Exit Code</returns>
        public static int MainCUI(string[] args)
        {
            var app = new CommandLineApplication(throwOnUnexpectedArg: false);
            app.Name = "AyanoBuilder for FatNoder";
            app.Description = "Transcompiler for FatNoder";
            app.HelpOption("-h|--help");
            app.Command("transcompile", command =>
            {
                command.Description = "compile code";
                command.HelpOption("-h|--help");

                var xmlArgument = command.Argument("xml", "XML Path");
                var OutArgument = command.Argument("out", "output cs path");
                command.OnExecute(() =>
                {
                    if (xmlArgument.Value == null)
                    {
                        command.ShowHelp();
                        return 1;
                    }
                    if (OutArgument.Value == null)
                    {
                        command.ShowHelp();
                        return 1;
                    }
                    ConsoleWrapper.GreenPrint($"xml : {xmlArgument.Value} cs:{OutArgument.Value}");
                    if (!File.Exists(xmlArgument.Value))
                    {
                        ConsoleWrapper.RedPrint($"Error!\n {xmlArgument.Value} is not found! ");
                        return 2;
                    }
                    #region XML Load and Struct
                    List<Type> knownlists = new();
                    using (var inputstream = new StreamReader(xmlArgument.Value))
                    {
                        {
                            XmlDocument xmlDoc = new XmlDocument();
                            xmlDoc.Load(inputstream);
                            XmlNode root = xmlDoc.DocumentElement;
                            foreach (XmlNode node in root.ChildNodes)
                            {

                                foreach (XmlNode node2 in node.ChildNodes)
                                {
                                    if (node2.Name == "Node")
                                    {
                                        foreach (XmlNode node3 in node2.ChildNodes)
                                        {
                                            if (node3.Name == "modeltype")
                                            {
                                                //Console.WriteLine(node3.InnerText);
                                                knownlists.Add(Type.GetType(node3.InnerText));
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    using (var inputstream = new StreamReader(xmlArgument.Value))
                    {
                        DataContractSerializer serializer =
                            new(typeof(XmlRootN), knownlists);
                        using (XmlReader xr = XmlReader.Create(inputstream))
                        {
                            XmlRootN obj = (XmlRootN)serializer.ReadObject(xr);
                            var roots = obj.nodes;
                            XML_NodeModel rootnode = null;
                            foreach (var obkujn in obj.nodes)
                            {
                                if(obkujn is IMethodPointBase)
                                {
                                    rootnode = obkujn;
                                }
                            }

                            var ModelEnumerator = new NodeModelEnumerator(rootnode, roots);
                            ;

                            var compilerstr = NodeAyanoCompiler.TransCompile(ModelEnumerator);
                            using(var stream=new StreamWriter(OutArgument.Value))
                            {
                                stream.Write(compilerstr);
                            }
                        }
                    }
                    #endregion
                    return 0;
                });
            });
            app.OnExecute(() =>
            {
                ConsoleWrapper.BluePrint("No opt");
                app.ShowHelp();
                return 0;
            });
            return app.Execute(args);
        }
    }
}
