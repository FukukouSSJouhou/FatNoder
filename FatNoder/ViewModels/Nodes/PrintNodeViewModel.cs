using DynamicData;
using FatNoder.Model.Transc;
using FatNoder.Serializer.Node.Xml;
using NodeCoreSystem.Model.Nodes;
using NodeCoreSystemVMLibs.ViewModels.Nodes;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeCoreSystemNodeVM;
using NodeNetworkJH.ViewModels;
using NodeCoreSystem.HensuuV;
using FatNoder.Properties;
using FatNoder.ViewModels.Ports;

namespace FatNoder.ViewModels.Nodes
{
    public partial class PrintNodeViewModel : StatementNodeViewModelBase, INodeViewModelBase
    {
        static PrintNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<PrintNodeViewModel>));
        }
        
        public ValueNodeInputViewModel<HensuuUkewatashi?> PrintInput { get; }
        [ModelAyano]
        private PrintNodeModel _model = new PrintNodeModel();
        public PrintNodeViewModel(Guid UUID):base(UUID)
        {
            InitAyanoVMB();
            PrintInput = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "Printcontent",
                Label = Resources.PrintNodeViewModel_PRINTCONTENT,
                MaxConnections = 1,
                Port = new NodePortViewModel
                {
                    Node_PortType = PortType.Valuable
                }
            };
            PrintInput.ValueChanged.Subscribe(newvalue =>
            {
                //_model.Value = newvalue;
            });

            _model.Inputs = new XMLNodeInputS
            {
                new XMLNodeInput()
                {
                    Name = PrintInput.Name,
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
            PrintInput.Connections.CountChanged.Subscribe(newvalue =>
            {
                foreach (XMLNodeInput xs in _model.Inputs.Where(d =>
                {
                    return d.Name == PrintInput.Name;
                }))
                {
                    xs.connections.Clear();
                    foreach (ConnectionViewModel cv in PrintInput.Connections.Items)
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
            this.Inputs.Add(PrintInput);
            InputFlow.Port = new NodePortViewModel
            {
                Node_PortType = PortType.Statement
            };
            OutputFlow.Port = new NodePortViewModel
            {
                Node_PortType = PortType.Statement
            };
        }

        public PrintNodeViewModel()
        {
            InitAyanoVMB();
            PrintInput = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "Printcontent",
                Label = Resources.PrintNodeViewModel_PRINTCONTENT,
                MaxConnections = 1,
                Port = new NodePortViewModel
                {
                    Node_PortType = PortType.Valuable
                }
            };
            PrintInput.ValueChanged.Subscribe(newvalue =>
            {
                //_model.Value = newvalue;
            });

            _model.Inputs = new XMLNodeInputS
            {
                new XMLNodeInput()
                {
                    Name = PrintInput.Name,
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
            PrintInput.Connections.CountChanged.Subscribe(newvalue =>
            {
                foreach (XMLNodeInput xs in _model.Inputs.Where(d =>
                {
                    return d.Name == PrintInput.Name;
                }))
                {
                    xs.connections.Clear();
                    foreach (ConnectionViewModel cv in PrintInput.Connections.Items)
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
            this.Inputs.Add(PrintInput);
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

            Name = Properties.Resources.MainViewModel_PrintString;
            Position = new System.Windows.Point
            {
                X = newmodelbs.Points.X,
                Y = newmodelbs.Points.Y
            };
            _model.Value = ((PrintNodeModel)newmodelbs).Value;
        }
    }
}
