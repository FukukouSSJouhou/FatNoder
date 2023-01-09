using NodeCoreSystemVMLibs.ViewModels.Nodes;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeCoreSystemNodeVM;
using NodeCoreSystem.Model.Nodes;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeCoreSystem.HensuuV;
using FatNoder.Model.Transc;
using NodeNetworkJH.ViewModels;
using DynamicData;
using FatNoder.Serializer.Node.Xml;
using FatNoder.ViewModels.Ports;

namespace FatNoder.ViewModels.Nodes
{
    public partial class IfNodeViewModel : StatementNodeViewModelBase, INodeViewModelBase
    {
        public ValueNodeInputViewModel<HensuuUkewatashi?> InputX { get; }
        public ValueListNodeInputViewModel<StatementCls> OutIfX { get; }
        public ValueListNodeInputViewModel<StatementCls> ElseIfX { get; }
        static IfNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<IfNodeViewModel>));
        }
        [ModelCoreSystem]
        private IfNodeModel _model = new IfNodeModel();
        public IfNodeViewModel(Guid uuid) : base(uuid)
        {
            InitAyanoVMB();
            InputX = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "Condition",
                Label=Properties.Resources.IfNodeViewModel_ConditionLabel,
                MaxConnections=1
            };
            OutIfX = new ValueListNodeInputViewModel<StatementCls>
            {
                Name = "Then",
                Label = Properties.Resources.IfNodeViewModel_ThenLabel,
                MaxConnections = 1,
                PortPosition = PortPosition.Right
            };
            ElseIfX = new ValueListNodeInputViewModel<StatementCls>
            {
                Name = "Else",
                Label = Properties.Resources.IfNodeViewModel_ElseLabel,
                MaxConnections = 1,
                PortPosition = PortPosition.Right
            };
            Initkun();
        }
        public IfNodeViewModel() : base()
        {
            InitAyanoVMB();
            InputX = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "Condition",
                Label = Properties.Resources.IfNodeViewModel_ConditionLabel,
                MaxConnections = 1
            };
            OutIfX = new ValueListNodeInputViewModel<StatementCls>
            {
                Name = "Then",
                Label = Properties.Resources.IfNodeViewModel_ThenLabel,
                MaxConnections = 1,
                PortPosition = PortPosition.Right
            };
            ElseIfX = new ValueListNodeInputViewModel<StatementCls>
            {
                Name = "Else",
                Label = Properties.Resources.IfNodeViewModel_ElseLabel,
                MaxConnections = 1,
                PortPosition = PortPosition.Right
            };
            Initkun();
        }
        public void Initkun()
        {

            _model.Inputs = new XMLNodeInputS
            {
                new XMLNodeInput()
                {
                    Name = InputX.Name,
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
            _model.InputStates.Add(new XMLNodeInputStatement()
            {
                States=new XMLNodeInputStatementLS(),
                Name = OutIfX.Name
            });
            _model.InputStates.Add(new XMLNodeInputStatement()
            {
                States=new XMLNodeInputStatementLS(),
                Name = ElseIfX.Name
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
            this.WhenAnyObservable(vm => vm.OutIfX.Values.CountChanged).Subscribe(newvalue =>
            {

                foreach (XMLNodeInputStatement xs in _model.InputStates.Where(
                    d =>
                    {
                        return d.Name == OutIfX.Name;
                    }))
                {
                    xs.States.Clear();
                    foreach (StatementCls guidkun in OutIfX.Values.Items)
                    {
                        xs.States.Add(guidkun.UUID);
                    }
                }
            });
            this.WhenAnyObservable(vm => vm.ElseIfX.Values.CountChanged).Subscribe(newvalue =>
            {

                foreach (XMLNodeInputStatement xs in _model.InputStates.Where(
                    d =>
                    {
                        return d.Name == ElseIfX.Name;
                    }))
                {
                    xs.States.Clear();
                    foreach (StatementCls guidkun in ElseIfX.Values.Items)
                    {
                        xs.States.Add(guidkun.UUID);
                    }
                }
            });
            InputX.Connections.CountChanged.Subscribe(newvalue =>
            {

                foreach (XMLNodeInput xs in _model.Inputs.Where(d =>
                {
                    return d.Name == InputX.Name;
                }))
                {
                    xs.connections.Clear();
                    foreach (ConnectionViewModel cv in InputX.Connections.Items)
                    {
                        //Console.WriteLine($"{cv.Input.Name},{cv.Input.Parent.UUID}");
                        xs.connections.Add(
                            new XMLNodeInputConnect
                            {
                                Name = cv.Output.Name,
                                Target = cv.Output.Parent.UUID,
                                InputOnly = false
                            });
                    }
                }
            });
            this.Inputs.Add(OutIfX);
            this.Inputs.Add(ElseIfX);
            this.Inputs.Add(InputX);
            InputFlow.Port = new NodePortViewModel
            {
                Node_PortType = PortType.Statement
            };
            OutputFlow.Port = new NodePortViewModel
            {
                Node_PortType = PortType.Statement
            };
        } 
        /// <inheritdoc/>

        public void ChangeStates(XML_NodeModel newmodelbs)
        {

            Name = Properties.Resources.IfNodeViewModel_IfNodeName;
            Position = new System.Windows.Point
            {
                X = newmodelbs.Points.X,
                Y = newmodelbs.Points.Y
            };
            _model.Value = ((IfNodeModel)newmodelbs).Value;
        }
    }
}
