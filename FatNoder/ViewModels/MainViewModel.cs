using DynamicData;
using FatNoder.Model.Transc;
using FatNoder.ViewModels.Conv;
using FatNoder.ViewModels.Nodes;
using NodeNetworkJH.Toolkit.BreadcrumbBar;
using NodeNetworkJH.Toolkit.NodeList;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeNetworkJH.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public ReactiveCommand<Unit,Unit> CreateTest { get; }
        public void add_project(String Name)
        {

        }
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

            ReturnNodeViewModel<string> returnnodekun = new ReturnNodeViewModel<string> { CanBeRemovedByUser = false,Name="StringReturn" };
            Network.Nodes.Add(returnnodekun);
            MethodEntryPointVIewModel mainnodekun = new MethodEntryPointVIewModel { CanBeRemovedByUser = false, Name = "MainEntryPoint" };
            Network.Nodes.Add(mainnodekun);
            NodeList.AddNodeType(() => new InputNodeViewModel<int> { Name="IntInput"});
            NodeList.AddNodeType(() => new InputNodeViewModel<string> { Name="StringInput"});
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
                string nm;

                foreach (NodeViewModel n in Network.Nodes.Items){
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
                }
            });

        }

    }
}
