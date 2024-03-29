﻿using DynamicData;
using FatNoder.Model;
using FatNoder.Model.Transc;
using FatNoder.Serializer.Node.Xml;
using FatNoder.ViewModels.Conv;
using FatNoder.ViewModels.Nodes;
using FatNoder.ViewModels.Nodes.EnzanNodes;
using FatNoder.ViewModels.Nodes.Http;
using FatNoder.ViewModels.Nodes.Sentences;
using NodeAyano;
using NodeAyano.Model.Enumerator;
using NodeAyano.Model.Nodes;
using NodeAyanoVMLibs.ViewModels.Nodes;
using NodeNetworkJH.Toolkit.BreadcrumbBar;
using NodeNetworkJH.Toolkit.Layout.ForceDirected;
using NodeNetworkJH.Toolkit.NodeList;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeNetworkJH.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FatNoder.ViewModels
{
    class NetworkBreadcrumb : BreadcrumbViewModel
    {
        #region Network
        private NetworkViewModel _network;
        public NetworkViewModel Network
        {
            get => _network;
            set => this.RaiseAndSetIfChanged(ref _network, value);
        }
        #endregion
    }
    /// <summary>
    /// MainWindowのViewModel!
    /// </summary>
    public class MainViewModel : ReactiveObject, IActivatableViewModel
    {
        #region Network
        private readonly ObservableAsPropertyHelper<NetworkViewModel> _network;
        public NetworkViewModel Network => _network.Value;
        #endregion

        public BreadcrumbBarViewModel NetworkBreadcrumbBar { get; } = new BreadcrumbBarViewModel();
        public NodeListViewModel NodeList { get; } = new NodeListViewModel();
        #region buttons?
        public ReactiveCommand<Unit, Unit> AutoLayout { get; }
        public ReactiveCommand<Unit, Unit> StartAutoLayoutLive { get; }
        public ReactiveCommand<Unit, Unit> StopAutoLayoutLive { get; }
        public ReactiveCommand<Unit, Unit> TestPhasekun { get; }
        public ReactiveCommand<Unit, Unit> CompilePhasekun { get; }

        public ReactiveCommand<Unit, Unit> CompileandrunPhasekun { get; }
        public ReactiveCommand<Unit, Unit> GroupNodes { get; }
        public ReactiveCommand<Unit, Unit> UngroupNodes { get; }
        public ReactiveCommand<Unit, Unit> OpenGroup { get; }
        public ReactiveCommand<Unit, Unit> CreateTest { get; }
        #endregion
        #region dialog

        public ReactiveCommand<Unit, SaveFileRequest> SaveXMLFileCommand { get; private set; }
        public Interaction<SaveFileRequest, SaveFileRequest> SaveXMLFileDialog { get; set; }
        public ReactiveCommand<Unit, string> LoadXMLFileCommand { get; private set; }
        public Interaction<string, string> LoadXMLFileDialog { get; set; }

        #endregion
        public ViewModelActivator Activator { get; }
        private bool Lock_RefreshEvent = false;
        public void add_project(String Name)
        {

        }
        private ReturnNodeViewModel<int> returnnodekun;
        MethodEntryPointVIewModel mainnodekun;
        public IEnumerable<XML_NodeModel> GetNodeModels()
        {
            foreach (NodeViewModel nvm in Network.Nodes.Items)
            {
                if (nvm is INodeViewModelBase)
                {
                    INodeViewModelBase nbase = nvm as INodeViewModelBase;
                    yield return nbase.model;
                }
            }
        }
        public CSCodePreviewViewModel CPreviewViewModel { get; } = new CSCodePreviewViewModel();
        /// <summary>
        /// MainViewModel
        /// </summary>
        public MainViewModel()
        {
            this.WhenAnyValue(vm => vm.NetworkBreadcrumbBar.ActiveItem).Cast<NetworkBreadcrumb>()
                .Select(b => b?.Network)
                .ToProperty(this, vm => vm.Network, out _network);
            NetworkBreadcrumbBar.ActivePath.Add(new NetworkBreadcrumb
            {
                Name = "Main",
                Network = new NetworkViewModel()
            });

            returnnodekun = new ReturnNodeViewModel<int> { CanBeRemovedByUser = false, Name = "IntReturn" };
            Network.Nodes.Add(returnnodekun);
            mainnodekun = new MethodEntryPointVIewModel { CanBeRemovedByUser = false, Name = Properties.Resources.MainViewModel_MainEntryPoint };
            Network.Nodes.Add(mainnodekun);
            NodeList.AddNodeType(() => new PrintNodeViewModel { Name =Properties.Resources.MainViewModel_PrintString });
            NodeList.AddNodeType(() => new InputNodeViewModel<int> { Name = "IntInput" });
            NodeList.AddNodeType(() => new InputNodeViewModel<string> { Name = "StringInput" });
            NodeList.AddNodeType(() => new SetValueNodeViewModel<int> { Name = "IntSetValue" });
            NodeList.AddNodeType(() => new GetValueNodeViewModel { Name = Properties.Resources.MainViewModel_GetValue });
            NodeList.AddNodeType(() => new ValueEnzannEngineNodeViewModel { Name = Properties.Resources.MainViewModel_Calc });
            NodeList.AddNodeType(() => new IfNodeViewModel { Name = Properties.Resources.IfNodeViewModel_IfNodeName });
            NodeList.AddNodeType(() => new WhileNodeViewModel { Name = Properties.Resources.WhileNodeViewModel_WhileNodeName });
            NodeList.AddNodeType(() => new ConditionNodeViewModel { Name = Properties.Resources.ConditionNodeViewModel_Compare });
            NodeList.AddNodeType(() => new ForNodeViewModel { Name = Properties.Resources.ForNodeViewModel_Label });
            NodeList.AddNodeType(() => new HttpClientPostDataNodeViewModel { Name = "HTTP NODE" });

            Plugins.PluginLoader.Load_Plugins();
            this.WhenAnyObservable(vm => vm.Network.NetworkChanged).Subscribe(newvalue =>
            {
                if (!Lock_RefreshEvent) Refresh_Node();
            }
                );
            CreateTest = ReactiveCommand.Create(() =>
            {
                Console.WriteLine("Detamon");

                string nm;
                foreach (NodeViewModel n in Network.Nodes.Items)
                {
                    string uuid = n.UUID.ToString();

                    Console.WriteLine($"Name:{n.Name} UUID:{uuid} ");
                    foreach (NodeInputViewModel i in n.Inputs.Items)
                    {
                        dynamic dyi = i as dynamic;
                        object objkun = dyi as object;
                        Type t = objkun.GetType();
                        Console.WriteLine($"\tType:{t} ");
                        if (dyi is ValueListNodeInputViewModel<StatementCls>)
                        {
                            IObservableList<StatementCls> valueskun;
                            nm = dyi.Name as string;
                            valueskun = dyi.Values as IObservableList<StatementCls>;
                            foreach (StatementCls s in valueskun.Items)
                            {
                                Console.WriteLine($"\t\tChildUUID:{s.UUID} ");
                            }
                        }
                        else
                        {
                            NodeTextConverter.conv(dyi);
                        }

                    }
                }
            });
            TestPhasekun = ReactiveCommand.Create(() =>
            {
                List<Type> typelistkun = new List<Type>();
                XML_NodeModel modelkun = mainnodekun.model;
                typelistkun.Add(typeof(MethodEntryPoint));
                typelistkun.Add(typeof(XmlRootN));
                typelistkun.Add(typeof(CompileNodeBase));
                XmlRootN documentrootkun = new XmlRootN()
                {
                    nodes = new XMLRoot_NodesCLskun()
                };
                var roots = GetNodeModels();
                foreach (var root in roots)
                {
                    if (root.TYPE == "")
                    {
                        continue;
                    }
                    if (root.TYPE == null)
                    {
                        continue;
                    }
                    if (root.MODELTYPE == "")
                    {
                        continue;
                    }
                    if (root.MODELTYPE == null)
                    {
                        continue;
                    }
                    if (!typelistkun.Contains(Type.GetType(root.TYPE)))
                    {
                        if (Type.GetType(root.TYPE) != null)
                            typelistkun.Add(Type.GetType(root.TYPE));
                    }
                    if (!typelistkun.Contains(Type.GetType(root.MODELTYPE)))
                    {
                        if (Type.GetType(root.MODELTYPE) != null)
                            typelistkun.Add(Type.GetType(root.MODELTYPE));
                    }
                }
                var ModelEnumerator = new NodeModelEnumerator_ExSave(modelkun, roots);
                ModelEnumerator.Reset();
                while (ModelEnumerator.MoveNext())
                {
                    documentrootkun.nodes.Add(ModelEnumerator.Current);
                }

                using (var writer = new StringWriter())
                {

                    DataContractSerializer serializer =
                        new(typeof(XmlRootN), typelistkun);
                    var settings = new XmlWriterSettings()
                    {
                        Indent = true,
                        IndentChars = "    ",
                        Encoding = new System.Text.UTF8Encoding(false)
                    };
                    using (var xw = XmlWriter.Create(writer, settings))
                    {
                        serializer.WriteObject(xw, documentrootkun);
                    }
                    Console.WriteLine(writer.ToString());
                }
            });
            CompilePhasekun = ReactiveCommand.Create(() =>
            {

                List<Type> typelistkun = new List<Type>();
                XML_NodeModel modelkun = mainnodekun.model;
                typelistkun.Add(typeof(MethodEntryPoint));
                typelistkun.Add(typeof(XmlRootN));
                typelistkun.Add(typeof(CompileNodeBase));
                XmlRootN documentrootkun = new XmlRootN()
                {
                    nodes = new XMLRoot_NodesCLskun()
                };
                var roots = GetNodeModels();
                foreach (var root in roots)
                {
                    if (root.TYPE == "")
                    {
                        continue;
                    }
                    if (root.TYPE == null)
                    {
                        continue;
                    }
                    if (root.MODELTYPE == "")
                    {
                        continue;
                    }
                    if (root.MODELTYPE == null)
                    {
                        continue;
                    }
                    if (!typelistkun.Contains(Type.GetType(root.TYPE)))
                    {
                        if (Type.GetType(root.TYPE) != null)
                            typelistkun.Add(Type.GetType(root.TYPE));
                    }
                    if (!typelistkun.Contains(Type.GetType(root.MODELTYPE)))
                    {
                        if (Type.GetType(root.MODELTYPE) != null)
                            typelistkun.Add(Type.GetType(root.MODELTYPE));
                    }
                }
                var ModelEnumerator = new NodeModelEnumerator(modelkun, roots);

                var compilerstr = NodeAyanoCompiler.TransCompile(ModelEnumerator,roots);
                Console.WriteLine(compilerstr);

            });
            CompileandrunPhasekun = ReactiveCommand.Create(() =>
            {

                NodeAyanoCompiler.CompileAndRunExec(CPreviewViewModel.Code, out WeakReference alcWeakRef);
                int c = 0;
                for (c = 0; alcWeakRef.IsAlive && (c < 10);c++)
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                if (c < 10)
                {
                    Console.WriteLine("\u001b[38;2;0;255;0mUnloaded!\u001b[0m");
                }
                else
                {
                    Console.WriteLine("\u001b[38;2;255;0;0mUnload Failed!\u001b[0m");
                }
            }); 
            ForceDirectedLayouter layouter = new ForceDirectedLayouter();
            AutoLayout = ReactiveCommand.Create(() =>
            {
                layouter.Layout(new Configuration { Network = Network }, 10000);
            });
            Activator = new ViewModelActivator();
            this.WhenActivated(d =>
            {
                {

                    SaveXMLFileDialog = new Interaction<SaveFileRequest, SaveFileRequest>();
                    SaveXMLFileCommand = ReactiveCommand.CreateFromObservable(() =>
                    {


                        List<Type> typelistkun = new List<Type>();
                        XML_NodeModel modelkun = mainnodekun.model;
                        typelistkun.Add(typeof(MethodEntryPoint));
                        typelistkun.Add(typeof(XmlRootN));
                        typelistkun.Add(typeof(CompileNodeBase));
                        XmlRootN documentrootkun = new XmlRootN()
                        {
                            nodes = new XMLRoot_NodesCLskun()
                        };
                        var roots = GetNodeModels();
                        foreach (var root in roots)
                        {
                            if (root.TYPE == "")
                            {
                                continue;
                            }
                            if (root.TYPE == null)
                            {
                                continue;
                            }
                            if (root.MODELTYPE == "")
                            {
                                continue;
                            }
                            if (root.MODELTYPE == null)
                            {
                                continue;
                            }
                            if (!typelistkun.Contains(Type.GetType(root.TYPE)))
                            {
                                if (Type.GetType(root.TYPE) != null)
                                    typelistkun.Add(Type.GetType(root.TYPE));
                            }
                            if (!typelistkun.Contains(Type.GetType(root.MODELTYPE)))
                            {
                                if (Type.GetType(root.MODELTYPE) != null)
                                    typelistkun.Add(Type.GetType(root.MODELTYPE));
                            }
                        }
                        var ModelEnumerator = new NodeModelEnumerator_ExSave(modelkun, roots);
                        ModelEnumerator.Reset();
                        while (ModelEnumerator.MoveNext())
                        {
                            documentrootkun.nodes.Add(ModelEnumerator.Current);
                        }
                        foreach(var nodekun in roots.Where(d =>
                        {
                            return d.InputOnly;
                        }))
                        {

                            documentrootkun.nodes.Add(nodekun);
                        }
                        DataContractSerializer serializer =
                            new(typeof(XmlRootN), typelistkun);
                        return SaveXMLFileDialog.Handle(new SaveFileRequest()
                        {
                            FilePath = "",
                            Serializer = serializer,
                            RootXML = documentrootkun
                        }).Select(
                            x =>
                            {
                                return x;
                            }
                        );
                    }
                    );
                    SaveXMLFileCommand.Select(x => new SaveFileModel().SaveXML(x)).Subscribe(x => { Console.Error.WriteLine(x.Message); }).DisposeWith(d);
                }
                {
                    LoadXMLFileDialog = new Interaction<string, string>();
                    LoadXMLFileCommand = ReactiveCommand.CreateFromObservable(() =>
                    {
                        return LoadXMLFileDialog.Handle("").Select(
                            x =>
                            {
                                return x;
                            });
                    });
                    LoadXMLFileCommand.Select(x =>
                    {
                        #region XML Load and Struct
                        Lock_RefreshEvent = true;
                        List<Type> knownlists = new();
                        if (x == null) return "";
                        using (var inputstream = new StreamReader(x))
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
                        using (var inputstream = new StreamReader(x))
                        {
                            DataContractSerializer serializer =
                                new(typeof(XmlRootN), knownlists);
                            using (XmlReader xr = XmlReader.Create(inputstream))
                            {
                                XmlRootN obj = (XmlRootN)serializer.ReadObject(xr);
                                Network.Nodes.Clear();
                                foreach (XML_NodeModel n in obj.nodes)
                                {
                                    Type typekun = Type.GetType(n.TYPE);
                                    if (typekun == typeof(MethodEntryPointVIewModel))
                                    {
                                        mainnodekun = new MethodEntryPointVIewModel(n.UUID);
                                        Network.Nodes.Add(mainnodekun);
                                        mainnodekun.ChangeStates((MethodEntryPoint)n);
                                    }
                                    else
                                    {
                                        var nodekun = (INodeViewModelBase)System.Activator.CreateInstance(typekun, new object[] { n.UUID });
                                        Network.Nodes.Add((NodeViewModel)nodekun);
                                        nodekun.ChangeStates(n);
                                    }
                                }
                                foreach (XML_NodeModel n in obj.nodes)
                                {
                                    Type typekun = Type.GetType(n.TYPE);
                                    {
                                        if (n.InputStates != null)
                                            foreach (var CNBB in n.InputStates)
                                            {
                                                var targetportName = CNBB.Name;
                                                if (CNBB.States != null)
                                                    foreach (var targetid in CNBB.States)
                                                    {
                                                        foreach (var NVkun in Network.Nodes.Items)
                                                        {
                                                            if (NVkun.UUID == targetid)
                                                            {
                                                                foreach (var origkun in Network.Nodes.Items)
                                                                {
                                                                    if (origkun.UUID == n.UUID)
                                                                    {
                                                                        foreach (var InputObj in origkun.Inputs.Items)
                                                                        {
                                                                            if (InputObj.Name == targetportName)
                                                                            {
                                                                                foreach (var OutObj in NVkun.Outputs.Items)
                                                                                {
                                                                                    if (OutObj.Name == "In")
                                                                                    {
                                                                                        Network.Connections.Add(Network.ConnectionFactory(InputObj, OutObj));
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                        //Network.ConnectionFactory.Add(Network.ConnectionFactory());
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                            }
                                        if (n.Outputs != null)
                                            foreach (var outkun2344 in n.Outputs)
                                            {
                                                var SourceportName = outkun2344.Name;
                                                if (outkun2344.connections != null)
                                                    foreach (var xmlOC in outkun2344.connections)
                                                    {
                                                        foreach (var NVkun2 in Network.Nodes.Items)
                                                        {
                                                            if (NVkun2.UUID == n.UUID)
                                                            {
                                                                foreach (var origkun in Network.Nodes.Items)
                                                                {
                                                                    if (origkun.UUID == xmlOC.Target)
                                                                    {
                                                                        foreach (var OutObj in NVkun2.Outputs.Items)
                                                                        {
                                                                            if (OutObj.Name == outkun2344.Name)
                                                                            {
                                                                                foreach (var InObj in origkun.Inputs.Items)
                                                                                {
                                                                                    if (InObj.Name == xmlOC.Name)
                                                                                    {
                                                                                        Network.Connections.Add(Network.ConnectionFactory(InObj, OutObj));

                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                            }
                                        if (n.Inputs != null)
                                            foreach (var inkun2344 in n.Inputs)
                                            {
                                                var SourceportName = inkun2344.Name;
                                                if (inkun2344.connections != null)
                                                    foreach (var xmlOC in inkun2344.connections)
                                                    {
                                                        foreach (var NVkun2 in Network.Nodes.Items)
                                                        {
                                                            if (NVkun2.UUID == n.UUID)
                                                            {
                                                                foreach (var origkun in Network.Nodes.Items)
                                                                {
                                                                    if (origkun.UUID == xmlOC.Target)
                                                                    {
                                                                        foreach (var InObj in NVkun2.Inputs.Items)
                                                                        {
                                                                            if (InObj.Name == inkun2344.Name)
                                                                            {
                                                                                foreach (var OutObj in origkun.Outputs.Items)
                                                                                {
                                                                                    if (OutObj.Name == xmlOC.Name)
                                                                                    {
                                                                                        Network.Connections.Add(Network.ConnectionFactory(InObj, OutObj));

                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                            }
                                    }
                                }
                            }
                        }
                        Lock_RefreshEvent = false;
                        Refresh_Node();
                        #endregion

                        return "";
                    }).Subscribe(x =>
                    {

                    }).DisposeWith(d);
                }
            });

        }
        private void Refresh_Node()

        {
            List<Type> typelistkun = new List<Type>();
            XML_NodeModel modelkun = mainnodekun.model;
            typelistkun.Add(typeof(MethodEntryPoint));
            typelistkun.Add(typeof(XmlRootN));
            typelistkun.Add(typeof(CompileNodeBase));
            XmlRootN documentrootkun = new XmlRootN()
            {
                nodes = new XMLRoot_NodesCLskun()
            };
            var roots = GetNodeModels();
            foreach (var root in roots)
            {
                if (root.TYPE == "")
                {
                    continue;
                }
                if (root.TYPE == null)
                {
                    continue;
                }
                if (root.MODELTYPE == "")
                {
                    continue;
                }
                if (root.MODELTYPE == null)
                {
                    continue;
                }
                if (!typelistkun.Contains(Type.GetType(root.TYPE)))
                {
                    if (Type.GetType(root.TYPE) != null)
                        typelistkun.Add(Type.GetType(root.TYPE));
                }
                if (!typelistkun.Contains(Type.GetType(root.MODELTYPE)))
                {
                    if (Type.GetType(root.MODELTYPE) != null)
                        typelistkun.Add(Type.GetType(root.MODELTYPE));
                }
            }
            var ModelEnumerator = new NodeModelEnumerator(modelkun, roots);

            var SyntaxCompiled = NodeAyanoCompiler.TransCompileNode(ModelEnumerator, roots);
            CPreviewViewModel.Code = SyntaxCompiled;
        }

    }
}
