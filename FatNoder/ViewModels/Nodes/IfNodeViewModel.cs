using NodeAyanoVMLibs.ViewModels.Nodes;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AyanoNodeVM;
using NodeAyano.Model.Nodes;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeAyano.HensuuV;
using FatNoder.Model.Transc;
using NodeNetworkJH.ViewModels;
using DynamicData;
using FatNoder.Serializer.Node.Xml;

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
        [ModelAyano]
        private IfNodeModel _model = new IfNodeModel();
        public IfNodeViewModel(Guid uuid) : base(uuid)
        {
            InitAyanoVMB();
            InputX = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "Condition",
                Label="Condition",
                MaxConnections=1
            };
            OutIfX = new ValueListNodeInputViewModel<StatementCls>
            {
                Name = "Then",
                Label = "Then",
                MaxConnections = 1,
                PortPosition = PortPosition.Right
            };
            ElseIfX = new ValueListNodeInputViewModel<StatementCls>
            {
                Name = "Else",
                Label = "Else",
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
                Label = "Condition",
                MaxConnections = 1
            };
            OutIfX = new ValueListNodeInputViewModel<StatementCls>
            {
                Name = "Then",
                Label = "Then",
                MaxConnections = 1,
                PortPosition = PortPosition.Right
            };
            ElseIfX = new ValueListNodeInputViewModel<StatementCls>
            {
                Name = "Else",
                Label = "Else",
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
            this.Inputs.Add(InputX);
        } 
        /// <inheritdoc/>

        public void ChangeStates(XML_NodeModel newmodelbs)
        {

            Name = "IfNode";
            Position = new System.Windows.Point
            {
                X = newmodelbs.Points.X,
                Y = newmodelbs.Points.Y
            };
            _model.Value = ((IfNodeModel)newmodelbs).Value;
        }
    }
}
