using DynamicData;
using DynamicData.Alias;
using FatNoder.Model.Transc;
using FatNoder.Serializer.Node.Xml;
using NodeAyano.Model.Nodes;
using NodeAyanoVMLibs.ViewModels.Nodes;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeNetworkJH.ViewModels;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

using AyanoNodeVM;
namespace FatNoder.ViewModels.Nodes
{
    public partial class MethodEntryPointVIewModel : NodeVMBasekun, INodeViewModelBase
    {

        static MethodEntryPointVIewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<MethodEntryPointVIewModel>));
        }

        public ValueListNodeInputViewModel<StatementCls> Input { get; }
        [ModelAyano]
        private MethodEntryPoint _model = new MethodEntryPoint();
        public MethodEntryPointVIewModel()
        {
            model.TYPE = typeof(MethodEntryPointVIewModel).AssemblyQualifiedName;
            _model.MODELTYPE = typeof(MethodEntryPoint).AssemblyQualifiedName;

            this.UUIDChanged.Subscribe(newvalue =>
            {
                model.UUID = newvalue;
            });
            this.NameChanged.Subscribe(newvalue =>
            {
                model.Name = newvalue;
            });
            this.PositionChanged.Subscribe(newvalue =>
            {
                model.Points = new XMLNodeXY()
                {
                    X = newvalue.X,
                    Y = newvalue.Y
                };
            });
            Input = new CoderListInputViewModel<StatementCls>(typeof(StatementCls))
            {
                Name = "Out",
                PortPosition = PortPosition.Right,
                MaxConnections = 1
            };
            model.InputStates = new XMLNodeInputStatement_VMLS();
            model.InputStates.Add(new XMLNodeInputStatement()
            {
                States = new XMLNodeInputStatementLS(),
                Name = Input.Name
            });
            this.WhenAnyObservable(vm => vm.Input.Values.CountChanged).Subscribe(newvalue =>
            {
                foreach (XMLNodeInputStatement xs in model.InputStates.Where(d =>
                {
                    return d.Name == Input.Name;
                }))
                {
                    xs.States.Clear();
                    foreach (StatementCls guidkun in Input.Values.Items)
                    {
                        xs.States.Add(guidkun.UUID);
                    }
                }
            });
            this.Inputs.Add(Input);

        }
        public MethodEntryPointVIewModel(Guid UUID):base(UUID)
        {
            model.TYPE = typeof(MethodEntryPointVIewModel).AssemblyQualifiedName;
            _model.MODELTYPE = typeof(MethodEntryPoint).AssemblyQualifiedName;

            this.UUIDChanged.Subscribe(newvalue =>
            {
                model.UUID = newvalue;
            });
            this.NameChanged.Subscribe(newvalue =>
            {
                model.Name = newvalue;
            });
            this.PositionChanged.Subscribe(newvalue =>
            {
                model.Points = new XMLNodeXY()
                {
                    X = newvalue.X,
                    Y = newvalue.Y
                };
            });
            Input = new CoderListInputViewModel<StatementCls>(typeof(StatementCls))
            {
                Name = "Out",
                PortPosition = PortPosition.Right,
                MaxConnections = 1
            };
            model.InputStates = new XMLNodeInputStatement_VMLS();
            model.InputStates.Add(new XMLNodeInputStatement()
            {
                States = new XMLNodeInputStatementLS(),
                Name = Input.Name
            });
            this.WhenAnyObservable(vm => vm.Input.Values.CountChanged).Subscribe(newvalue =>
            {
                foreach (XMLNodeInputStatement xs in model.InputStates.Where(d =>
                {
                    return d.Name == Input.Name;
                }))
                {
                    xs.States.Clear();
                    foreach (StatementCls guidkun in Input.Values.Items)
                    {
                        xs.States.Add(guidkun.UUID);
                    }
                }
            });
            this.Inputs.Add(Input);

        }

        public void ChangeStates(XML_NodeModel mdel)
        {
            Name = mdel.Name;
            Position = new System.Windows.Point
            {
                X = mdel.Points.X,
                Y = mdel.Points.Y
            };
        }
    }
}
