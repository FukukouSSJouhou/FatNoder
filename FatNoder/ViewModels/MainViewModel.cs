using DynamicData;
using FatNoder.Model.Transc;
using FatNoder.Serializer.Node.Xml;
using FatNoder.ViewModels.Conv;
using FatNoder.ViewModels.Nodes;
using NodeAyano.Model.Enumerator;
using NodeAyano.Model.Nodes;
using NodeNetworkJH.Toolkit.BreadcrumbBar;
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
    public class MainViewModel:ReactiveObject
    {
        #region Network
        private readonly ObservableAsPropertyHelper<NetworkViewModel> _network;
        public NetworkViewModel Network => _network.Value;
        #endregion

        public BreadcrumbBarViewModel NetworkBreadcrumbBar { get; } = new BreadcrumbBarViewModel();
        public NodeListViewModel NodeList { get; } = new NodeListViewModel();

        public ReactiveCommand<Unit, Unit> AutoLayout { get; }
        public ReactiveCommand<Unit, Unit> StartAutoLayoutLive { get; }
        public ReactiveCommand<Unit, Unit> StopAutoLayoutLive { get; }
        public ReactiveCommand<Unit, Unit> TestPhasekun { get; }

        public ReactiveCommand<Unit, Unit> GroupNodes { get; }
        public ReactiveCommand<Unit, Unit> UngroupNodes { get; }
        public ReactiveCommand<Unit, Unit> OpenGroup { get; }
        public ReactiveCommand<Unit, Unit> CreateTest { get; }
        public void add_project(String Name)
        {

        }
        public IEnumerable<XML_NodeModel> GetNodeModels()
        {
            foreach(NodeViewModel nvm in Network.Nodes.Items)
            {
                if(nvm is INodeViewModelBase)
                {
                    INodeViewModelBase nbase = nvm as INodeViewModelBase;
                    yield return nbase.model;
                }
            }
        }
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

            ReturnNodeViewModel<int> returnnodekun = new ReturnNodeViewModel<int> { CanBeRemovedByUser = false,Name="IntReturn" };
            Network.Nodes.Add(returnnodekun);
            MethodEntryPointVIewModel mainnodekun = new MethodEntryPointVIewModel { CanBeRemovedByUser = false, Name = "MainEntryPoint" };
            Network.Nodes.Add(mainnodekun);
            NodeList.AddNodeType(() => new InputNodeViewModel<int> { Name="IntInput"});
            NodeList.AddNodeType(() => new InputNodeViewModel<string> { Name="StringInput"});
            NodeList.AddNodeType(() => new PrintNodeViewModel { Name = "PrintString" });
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
                    if(root.TYPE == "")
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
                        if(Type.GetType(root.TYPE) != null)
                        typelistkun.Add(Type.GetType(root.TYPE));
                    }
                    if (!typelistkun.Contains(Type.GetType(root.MODELTYPE)))
                    {
                        if (Type.GetType(root.MODELTYPE) != null)
                            typelistkun.Add(Type.GetType(root.MODELTYPE));
                    }
                }
                var ModelEnumerator = new NodeModelEnumerator(modelkun, roots);
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
                        Encoding = Encoding.UTF8
                    };
                    using (var xw = XmlWriter.Create(writer, settings))
                    {
                        serializer.WriteObject(xw, documentrootkun);
                    }
                    Console.WriteLine(writer.ToString());
                }
                /*Serializer.Node.Xml.XmlRootN xr = Serializer.Node.Xml.ConvertXMLkun.Serializekun(Network,ref typelistkun);
                using(var writer = new StringWriter())
                {

                    DataContractSerializer serializer =
                        new (typeof(Serializer.Node.Xml.XmlRootN), typelistkun);
                    var settings = new XmlWriterSettings()
                    {
                        Indent=true,
                        IndentChars="    ",
                        Encoding = Encoding.UTF8
                    };
                    using (var xw = XmlWriter.Create(writer,settings))
                    {
                        serializer.WriteObject(xw, xr);
                    }
                    Console.WriteLine(writer.ToString());
                }
                /*
                
                string nm;

                foreach (NodeViewModel n in Network.Nodes.Items){
                    Debug.Print(n.GetType().ToString());
                    Debug.Print(n.UUID.ToString());
                    foreach(NodeInputViewModel i in n.Inputs.Items)
                    {
                        dynamic dyi = i as dynamic;
                        if( dyi is ValueListNodeInputViewModel<StatementCls>)
                        {
                            IObservableList<StatementCls> valueskun;
                            nm = dyi.Name as string;
                            Debug.Print(nm);
                            valueskun=dyi.Values as IObservableList<StatementCls>;
                            foreach (StatementCls s in valueskun.Items)
                            {
                                Debug.Print(s.UUID.ToString());
                            }
                        }

                    }
                }*/
            });
            

        }

    }
}
