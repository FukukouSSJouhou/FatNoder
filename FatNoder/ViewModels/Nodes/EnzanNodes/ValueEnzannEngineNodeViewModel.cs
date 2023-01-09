using NodeCoreSystemVMLibs.ViewModels.Nodes;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NodeCoreSystemNodeVM;
using DynamicData;
using NodeCoreSystem.HensuuV;
using NodeNetworkJH.Toolkit.ValueNode;
using FatNoder.Serializer.Node.Xml;
using NodeNetworkJH.ViewModels;
using NodeCoreSystem.Model.Nodes.ValueEnzann;
using FatNoder.ViewModels.Nodes.EnzanNodes.Editors;
using FatNoder.ViewModels.Ports;

namespace FatNoder.ViewModels.Nodes.EnzanNodes
{
    public partial class ValueEnzannEngineNodeViewModel : NodeVMBasekun, INodeViewModelBase
    {
        static ValueEnzannEngineNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ValueEnzannEngineNodeViewModel>));
        }
        [ModelAyano]
        private ValueEnzannEngineNodeModel _model = new ValueEnzannEngineNodeModel();
        /// <summary>
        /// Output Value?
        /// </summary>
        public ValueNodeOutputViewModel<HensuuUkewatashi?> Output { get; }
        private HensuuUkewatashi hkun = new HensuuUkewatashi();
        public ValueNodeInputViewModel<HensuuUkewatashi?> Input1 { get; }

        public ValueNodeInputViewModel<HensuuUkewatashi?> Input2 { get; }
        public ValueNodeInputViewModel<ValueEnzannEngineType?> ValueTypeInput { get; }

        public ValueEnzannEngineNodeViewModel(Guid uuid) : base(uuid)
        {
            InitAyanoVMB();
            _model.InputOnly = true;
            Output = new ValueNodeOutputViewModel<HensuuUkewatashi?>
            {
                Name = "Value",
                Label = "Value",
                Value = this.WhenAnyValue(vm => vm.hkun)
            };
            Input1 = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "Input1",
                Label = "Input1",
                MaxConnections = 1
            };
            Input2 = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "Input2",
                Label = "Input2",
                MaxConnections = 1
            };
            ValueTypeInput = new ValueNodeInputViewModel<ValueEnzannEngineType?>
            {
                Name = "CalcType",
                Label = Properties.Resources.ValueEnzannEngineNodeViewModel_CalcType,
                MaxConnections = 1

            };
            InitConstructor();
        }
        public ValueEnzannEngineNodeViewModel() : base()
        {

            InitAyanoVMB();
            _model.InputOnly = true;
            Output = new ValueNodeOutputViewModel<HensuuUkewatashi?>
            {
                Name = "Value",
                Label = "Value",
                Value = this.WhenAnyValue(vm => vm.hkun)
            };
            Input1 = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "Input1",
                Label = "Input1",
                MaxConnections = 1
            };
            Input2 = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "Input2",
                Label = "Input2",
                MaxConnections = 1
            };
            ValueTypeInput = new ValueNodeInputViewModel<ValueEnzannEngineType?>
            {
                Name = "CalcType",
                Label = Properties.Resources.ValueEnzannEngineNodeViewModel_CalcType,
                MaxConnections = 1

            };
            InitConstructor();
        }
        private void InitConstructor()
        {

            ValueTypeInput.ValueChanged.Subscribe(newvalue =>
            {
                if(newvalue != null)
                _model.CalcType = newvalue.Value;
            });
            ValueTypeInput.Editor = new ValueEnzannEngineTypeEditorViewModel();
            _model.Outputs = new XMLNodeOutputS
            {
                new XMLNodeOutput()
                {
                    Name = Output.Name,
                    connections=new XMLNodeOutputConnectS
                    {

                    }
                }
            };

            _model.Inputs = new XMLNodeInputS
            {
                new XMLNodeInput()
                {
                    Name = Input1.Name,
                    connections=new XMLNodeInputConnectS
                    {

                    }
                },
                new XMLNodeInput()
                {
                    Name = Input2.Name,
                    connections=new XMLNodeInputConnectS
                    {

                    }
                }
            };
            Input1.Connections.CountChanged.Subscribe(newvalue =>
            {

                foreach (XMLNodeInput xs in _model.Inputs.Where(d =>
                {
                    return d.Name == Input1.Name;
                }))
                {
                    xs.connections.Clear();
                    foreach (ConnectionViewModel cv in Input1.Connections.Items)
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
            Input2.Connections.CountChanged.Subscribe(newvalue =>
            {

                foreach (XMLNodeInput xs in _model.Inputs.Where(d =>
                {
                    return d.Name == Input2.Name;
                }))
                {
                    xs.connections.Clear();
                    foreach (ConnectionViewModel cv in Input2.Connections.Items)
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
            this.Outputs.Add(Output);
            this.Inputs.Add(ValueTypeInput);
            this.Inputs.Add(Input1);
            this.Inputs.Add(Input2);
            ValueTypeInput.Port.IsVisible = false;

        }
        ///<inheritdoc/>
        public void ChangeStates(XML_NodeModel newmodelbs)
        {

            Name = Properties.Resources.MainViewModel_Calc;
            Position = new System.Windows.Point
            {
                X = newmodelbs.Points.X,
                Y = newmodelbs.Points.Y
            };
            _model.CalcType = ((ValueEnzannEngineNodeModel)newmodelbs).CalcType;
            ((ValueEnzannEngineTypeEditorViewModel)ValueTypeInput.Editor).SelectViewKun(_model.CalcType);
        }

    }
}
