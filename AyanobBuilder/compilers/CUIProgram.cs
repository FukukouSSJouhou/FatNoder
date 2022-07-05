using AyanoBuilder.CUItools;
using FatNoder.Serializer.Node.Xml;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Classification;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
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
        class Walker : SyntaxWalker
        {
            public override void Visit(SyntaxNode node)
            {
                if (node != null)
                    Console.WriteLine("[Node  - Type: {0}, Kind: {1}]\n{2}\n", node.GetType().Name, node.Kind(), node);

                base.Visit(node);
            }
        }
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

                var analyzeOption = command.Option("--analyze", "Analyze", CommandOptionType.NoValue);
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
                        ConsoleWrapper.BluePrint("[Phase 1] Loading XML File...");
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
                        ConsoleWrapper.BluePrint("[Phase 2] Loading XML File...");
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

                            var compilerstr = NodeAyanoCompiler.TransCompile(ModelEnumerator,roots);
                            using(var stream=new StreamWriter(OutArgument.Value))
                            {
                                stream.Write(compilerstr);
                            }
                            if (analyzeOption.HasValue())
                            {
                                NodeAyanoCompiler.AnalyzeAndTestCompilekun(compilerstr, d =>
                                {
                                    var pos = d.Location.GetLineSpan();
                                    var location = "(" + pos.Path + "@Line" + (pos.StartLinePosition.Line + 1) + ":" + (pos.StartLinePosition.Character + 1) + ")";
                                    switch (d.Severity)
                                    {
                                        case DiagnosticSeverity.Warning:
                                            Console.WriteLine($"\u001b[38;2;255;255;0m[{d.Severity}, {location}] {d.Id}, {d.GetMessage()}\u001b[0m");
                                            break;
                                        case DiagnosticSeverity.Error:
                                            Console.WriteLine($"\u001b[38;2;255;0;0m[{d.Severity}, {location}] {d.Id}, {d.GetMessage()}\u001b[0m");
                                            break;
                                        case DiagnosticSeverity.Hidden:
                                            Console.WriteLine($"\u001b[38;2;255;0;255m[{d.Severity}, {location}] {d.Id}, {d.GetMessage()}\u001b[0m");
                                            break;
                                        default:
                                            Console.WriteLine($"[{d.Severity}, {location}] {d.Id}, {d.GetMessage()}");
                                            break;
                                    }
                                });
                            }
                        }
                    }
                    #endregion
                    return 0;
                });
            });
            app.Command("transcompile_stdout", command =>
            {
                command.Description = "compile code and print";
                command.HelpOption("-h|--help");

                var xmlArgument = command.Argument("xml", "XML Path");
                var nocolorOption = command.Option("--nocolor", "no color syntax option", CommandOptionType.NoValue);
                command.OnExecute(() =>
                {
                    if (xmlArgument.Value == null)
                    {
                        command.ShowHelp();
                        return 1;
                    }
                    bool ISColorEnabled = !nocolorOption.HasValue();
                    ISColorEnabled = false;
                    ConsoleWrapper.GreenPrint($"xml : {xmlArgument.Value}");
                    if (!File.Exists(xmlArgument.Value))
                    {
                        ConsoleWrapper.RedPrint($"Error!\n {xmlArgument.Value} is not found! ");
                        return 2;
                    }
                    #region XML Load and Struct
                    List<Type> knownlists = new();
                    using (var inputstream = new StreamReader(xmlArgument.Value))
                    {
                        ConsoleWrapper.BluePrint("[Phase 1] Loading XML File...");
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
                        ConsoleWrapper.BluePrint("[Phase 2] Loading XML File...");
                        DataContractSerializer serializer =
                            new(typeof(XmlRootN), knownlists);
                        using (XmlReader xr = XmlReader.Create(inputstream))
                        {
                            XmlRootN obj = (XmlRootN)serializer.ReadObject(xr);
                            var roots = obj.nodes;
                            XML_NodeModel rootnode = null;
                            foreach (var obkujn in obj.nodes)
                            {
                                if (obkujn is IMethodPointBase)
                                {
                                    rootnode = obkujn;
                                }
                            }

                            var ModelEnumerator = new NodeModelEnumerator(rootnode, roots);
                            ;

                            if (ISColorEnabled)
                            {

                                var compilernde = NodeAyanoCompiler.TransCompileNode(ModelEnumerator,roots);
                            }
                            else
                            {
                                var compilerstr = NodeAyanoCompiler.TransCompile(ModelEnumerator,roots);
                                Console.Write(compilerstr);
                                Console.Write("\n");
                            }
                        }
                        ConsoleWrapper.GreenPrint("Success!");
                    }
                    #endregion
                    return 0;
                });
            });
            app.Command("testros", command =>
            {
                command.Description = "test roslyn";
                command.HelpOption("-h|--help");
                command.OnExecute(() =>
                {
                    var sourceCode = @"
using System;
namespace tintin{
    class tinpo{
    static int Main(){
        int tdn=9;
        string tdn33=tdnx445;
        tdn=tdn+23;
        Console.WriteLine(tdn33);
        Console.Error.WriteLine(tdn33);
if(1 == 1){
}
if(1 > 1){
}
if(1 < 1){
}
if(1 <= 1){
}
if(1 >= 1){
}
if(1 != 1){
}
        return tdn;
    }
    }
}";
                    sourceCode = sourceCode.Replace("tdnx445", "\"tdn910\"");
                    var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
                    var rootNode = syntaxTree.GetRoot();
                    new Walker().Visit(rootNode);
                    return 0;
                });
            });
            app.Command("test_compile", command =>
            {
                command.Description = "test compile";
                command.HelpOption("-h|--help");
                command.OnExecute(() =>
                {
                    //var compilerstr = NodeAyanoCompiler.TransCompile(null);
                    //Console.WriteLine(compilerstr);
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
