using NodeAyanoVMLibs.ViewModels.Nodes;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AyanoNodeVM;
using DynamicData;
using NodeAyano.HensuuV;
using NodeNetworkJH.Toolkit.ValueNode;
using FatNoder.Serializer.Node.Xml;
using NodeNetworkJH.ViewModels;
using NodeAyano.Model.Nodes.ValueEnzann;


namespace FatNoder.ViewModels.Nodes.EnzanNodes
{
    public partial class SubtractNodeViewModel : NodeVMBasekun, INodeViewModelBase
    {
        static SubtractNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<SubtractNodeViewModel>));
        }
        [ModelAyano]
        private SubtractNodeModel _model = new SubtractNodeModel();

        /// <summary>
        /// Output Value?
        /// </summary>
        public ValueNodeOutputViewModel<HensuuUkewatashi?> Output { get; }
        private HensuuUkewatashi hkun = new HensuuUkewatashi();
        public ValueNodeInputViewModel<HensuuUkewatashi?> Input1 { get; }

        public ValueNodeInputViewModel<HensuuUkewatashi?> Input2 { get; }

        public SubtractNodeViewModel(Guid uuid) : base(uuid)
        {

            InitAyanoVMB();
            _model.InputOnly = true;
            Output = new ValueNodeOutputViewModel<HensuuUkewatashi?>
            {
                Name = "Value",
                Value = this.WhenAnyValue(vm => vm.hkun)
            };
            Input1 = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "Input1",
                MaxConnections = 1
            };
            Input2 = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "Input2",
                MaxConnections = 1
            };
            InitConstructor();
        }
        public SubtractNodeViewModel() : base()
        {

            InitAyanoVMB();
            _model.InputOnly = true;
            Output = new ValueNodeOutputViewModel<HensuuUkewatashi?>
            {
                Name = "Value",
                Value = this.WhenAnyValue(vm => vm.hkun)
            };
            Input1 = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "Input1",
                MaxConnections = 1
            };
            Input2 = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "Input2",
                MaxConnections = 1
            };
            InitConstructor();
        }
        private void InitConstructor()
        {

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
            this.Inputs.Add(Input1);
            this.Inputs.Add(Input2);

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
        }
    }
}
