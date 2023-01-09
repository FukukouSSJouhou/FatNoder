using FatNoder.Views;
using NodeCoreSystem.Model.Nodes;
using NodeCoreSystemVMLibs.ViewModels.Nodes;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeCoreSystemNodeVM;
using FatNoder.Serializer.Node.Xml;
using NodeNetworkJH.Toolkit.ValueNode;
using DynamicData;
using FatNoder.Model.Transc;
using NodeNetworkJH.ViewModels;
using NodeCoreSystem.HensuuV;
using FatNoder.ViewModels.Ports;

namespace FatNoder.ViewModels.Nodes
{
    public partial class SetValueNodeViewModel<T> : StatementNodeViewModelBase, INodeViewModelBase
    {
        static SetValueNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<SetValueNodeViewModel<T>>));
        }
        public ValueNodeInputViewModel<HensuuUkewatashi?> HensuuInput { get; }
        public ValueNodeInputViewModel<string?> NameInput { get; }
        [ModelAyano]
        private SetValueNodeModel<T> _model = new SetValueNodeModel<T>();
        ///<inheritdoc/>
        public SetValueNodeViewModel(Guid uuid) : base(uuid)
        {
InitAyanoVMB();
            HensuuInput = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "Value",
                Label = "Value",
                MaxConnections = 1
            };
            HensuuInput.ValueChanged.Subscribe(newvalue =>
            {
                //_model.Value = newvalue;
            });
            NameInput = new ValueNodeInputViewModel<string?>
            {
                Name = "Name",
                Label = "Name",
                MaxConnections = 1
            };
            NameInput.ValueChanged.Subscribe(newvalue =>
            {
                _model.ValueName = newvalue;
            });
            NameInput.Editor = new HannyouValueEditorViewModel<string>();

            _model.Inputs = new XMLNodeInputS
            {
                new XMLNodeInput()
                {
                    Name = HensuuInput.Name,
                    connections=new XMLNodeInputConnectS
                    {

                    }
                }
            };
            _model.InputStates = new XMLNodeInputStatement_VMLS();
            _model.InputStates.Add(new XMLNodeInputStatement()
            {
                States = new XMLNodeInputStatementLS(),
                Name = InputFlow.Name
            });
            this.WhenAnyObservable(vm => vm.InputFlow.Values.CountChanged).Subscribe(newvalue =>
            {
                foreach (XMLNodeInputStatement xs in _model.InputStates.Where(d =>
                {
                    return d.Name == InputFlow.Name;
                }))
                {
                    xs.States.Clear();
                    foreach (StatementCls guidkun in InputFlow.Values.Items)
                    {
                        xs.States.Add(guidkun.UUID);
                    }
                }
            });
            HensuuInput.Connections.CountChanged.Subscribe(newvalue =>
            {
                foreach (XMLNodeInput xs in _model.Inputs.Where(d =>
                {
                    return d.Name == HensuuInput.Name;
                }))
                {
                    xs.connections.Clear();
                    foreach (ConnectionViewModel cv in HensuuInput.Connections.Items)
                    {
                        //Console.WriteLine($"{cv.Input.Name},{cv.Input.Parent.UUID}");
                        xs.connections.Add(
                            new XMLNodeInputConnect
                            {
                                Name = cv.Output.Name,
                                Target = cv.Output.Parent.UUID,
                                InputOnly = true
                            });
                    }
                }

            });
            this.Inputs.Add(HensuuInput);
            NameInput.Port.IsVisible = false;
            this.Inputs.Add(NameInput);
            InputFlow.Port = new NodePortViewModel
            {
                Node_PortType = PortType.Statement
            };
            OutputFlow.Port = new NodePortViewModel
            {
                Node_PortType = PortType.Statement
            };
        }
        ///<inheritdoc/>
        public SetValueNodeViewModel() : base()
        {
            InitAyanoVMB();
            HensuuInput = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "Value",
                Label = "Value",
                MaxConnections = 1
            };
            HensuuInput.ValueChanged.Subscribe(newvalue =>
            {
                //_model.Value = newvalue;
            });

            NameInput = new ValueNodeInputViewModel<string?>
            {
                Name = "Name",
                Label = "Name",
                MaxConnections = 1
            };
            NameInput.ValueChanged.Subscribe(newvalue =>
            {
                _model.ValueName = newvalue;
            });
            NameInput.Editor = new HannyouValueEditorViewModel<string>();
            _model.Inputs = new XMLNodeInputS
            {
                new XMLNodeInput()
                {
                    Name = HensuuInput.Name,
                    connections=new XMLNodeInputConnectS
                    {

                    }
                }
            };
            _model.InputStates = new XMLNodeInputStatement_VMLS();
            _model.InputStates.Add(new XMLNodeInputStatement()
            {
                States = new XMLNodeInputStatementLS(),
                Name = InputFlow.Name
            });
            this.WhenAnyObservable(vm => vm.InputFlow.Values.CountChanged).Subscribe(newvalue =>
            {
                foreach (XMLNodeInputStatement xs in _model.InputStates.Where(d =>
                {
                    return d.Name == InputFlow.Name;
                }))
                {
                    xs.States.Clear();
                    foreach (StatementCls guidkun in InputFlow.Values.Items)
                    {
                        xs.States.Add(guidkun.UUID);
                    }
                }
            });
            HensuuInput.Connections.CountChanged.Subscribe(newvalue =>
            {
                foreach (XMLNodeInput xs in _model.Inputs.Where(d =>
                {
                    return d.Name == HensuuInput.Name;
                }))
                {
                    xs.connections.Clear();
                    foreach (ConnectionViewModel cv in HensuuInput.Connections.Items)
                    {
                        //Console.WriteLine($"{cv.Input.Name},{cv.Input.Parent.UUID}");
                        xs.connections.Add(
                            new XMLNodeInputConnect
                            {
                                Name = cv.Output.Name,
                                Target = cv.Output.Parent.UUID,
                                InputOnly = true
                            });
                    }
                }

            });
            this.Inputs.Add(HensuuInput);
            NameInput.Port.IsVisible = false;
            this.Inputs.Add(NameInput);
            InputFlow.Port = new NodePortViewModel
            {
                Node_PortType = PortType.Statement
            };
            OutputFlow.Port = new NodePortViewModel
            {
                Node_PortType = PortType.Statement
            };
        }
        ///<inheritdoc/>
        public void ChangeStates(XML_NodeModel newmodelbs)
        {

            Name = newmodelbs.Name;
            Position = new System.Windows.Point
            {
                X = newmodelbs.Points.X,
                Y = newmodelbs.Points.Y
            };
            _model.Value = ((SetValueNodeModel<T>)newmodelbs).Value;
            _model.ValueName = ((SetValueNodeModel<T>)newmodelbs).ValueName;
            ((HannyouValueEditorViewModel<string>)NameInput.Editor).Value = _model.ValueName;
        }
    }
}
