using DynamicData;
using FatNoder.Model.Transc;
using FatNoder.Serializer.Node.Xml;
using NodeCoreSystem.Model.Nodes;
using NodeCoreSystemVMLibs.ViewModels.Nodes;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeNetworkJH.ViewModels;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using AyanoNodeVM;
using NodeCoreSystem.HensuuV;
using FatNoder.ViewModels.Ports;

namespace FatNoder.ViewModels.Nodes
{
    /// <summary>
    /// 値を返却するNodeの基本形
    /// </summary>
    /// <typeparam name="T">型</typeparam>
    public partial class ReturnNodeViewModel<T> : NodeVMBasekun, INodeViewModelBase
    {
        
        static ReturnNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ReturnNodeViewModel<T>>));

        }
        public ValueNodeInputViewModel<HensuuUkewatashi?> ReturnInput { get; }
        public ValueNodeOutputViewModel<StatementCls> Flow { get; }
        public StatementCls StatementIfce { get; }
        [ModelAyano]
        private ReturnNodeModel<T> _model = new ReturnNodeModel<T>();

        public ReturnNodeViewModel(Guid UUID):base(UUID)
        {
            InitAyanoVMB();

            StatementIfce = StatementCls.GenStatementCls(this.UUID);
            ReturnInput = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "ValueRet",
                Label = "ValueRet",
                MaxConnections = 1,
                Port = new NodePortViewModel
                {
                    Node_PortType = PortType.Valuable
                }
            };
            ReturnInput.ValueChanged.Subscribe(newvalue =>
            {
                //_model.Value = newvalue;
            });
            Flow = new ValueNodeOutputViewModel<StatementCls>
            {
                Name = "In",
                Label = "In",
                MaxConnections = 1,
                Value = this.WhenAnyValue(vm => vm.StatementIfce),
                PortPosition = PortPosition.Left,
                Port = new NodePortViewModel
                {
                    Node_PortType = PortType.Statement
                }
            };
            _model.Inputs = new XMLNodeInputS
            {
                new XMLNodeInput()
                {
                    Name = ReturnInput.Name,
                    connections=new XMLNodeInputConnectS
                    {

                    }
                }
            };
            model.InputStates = new XMLNodeInputStatement_VMLS();
            model.InputStates.Add(new XMLNodeInputStatement());
            ReturnInput.Connections.CountChanged.Subscribe(newvalue =>
            {
                foreach (XMLNodeInput xs in _model.Inputs.Where(d =>
                {
                    return d.Name == ReturnInput.Name;
                }))
                {
                    xs.connections.Clear();
                    foreach (ConnectionViewModel cv in ReturnInput.Connections.Items)
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
            this.Inputs.Add(ReturnInput);
            this.Outputs.Add(Flow);
        }
        public ReturnNodeViewModel()
        {
            InitAyanoVMB();

            StatementIfce = StatementCls.GenStatementCls(this.UUID);
            ReturnInput = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "ValueRet",
                Label = "ValueRet",
                MaxConnections =1,
                Port = new NodePortViewModel
                {
                    Node_PortType = PortType.Valuable
                }
            };
            ReturnInput.ValueChanged.Subscribe(newvalue =>
            {
                //_model.Value = newvalue;
            });
            Flow = new ValueNodeOutputViewModel<StatementCls>
            {
                Name = "In",
                Label = "In",
                MaxConnections = 1,
                Value = this.WhenAnyValue(vm =>vm.StatementIfce),
                PortPosition=PortPosition.Left,
                Port = new NodePortViewModel
                {
                    Node_PortType = PortType.Statement
                }
            };

            _model.Inputs = new XMLNodeInputS
            {
                new XMLNodeInput()
                {
                    Name = ReturnInput.Name,
                    connections=new XMLNodeInputConnectS
                    {

                    }
                }
            };
            model.InputStates = new XMLNodeInputStatement_VMLS();
            model.InputStates.Add(new XMLNodeInputStatement());
            ReturnInput.Connections.CountChanged.Subscribe(newvalue =>
            {
                foreach (XMLNodeInput xs in _model.Inputs.Where(d =>
                {
                    return d.Name == ReturnInput.Name;
                }))
                {
                    xs.connections.Clear();
                    foreach (ConnectionViewModel cv in ReturnInput.Connections.Items)
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
            this.Inputs.Add(ReturnInput);
            this.Outputs.Add(Flow);
        }
        /// <inheritdoc/>
        public void ChangeStates(XML_NodeModel newmodelbs)
        {

            Name = newmodelbs.Name;
            Position = new System.Windows.Point
            {
                X = newmodelbs.Points.X,
                Y = newmodelbs.Points.Y
            };
            _model.Value = ((ReturnNodeModel<T>)newmodelbs).Value;
        }
    }
}
