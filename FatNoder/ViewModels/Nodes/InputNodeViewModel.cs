using NodeAyano.Model.Nodes;
using NodeAyanoVMLibs.ViewModels.Nodes;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AyanoNodeVM;
using FatNoder.Serializer.Node.Xml;
using System.Xml.Linq;
using DynamicData;
using NodeNetworkJH.ViewModels;

namespace FatNoder.ViewModels.Nodes
{
    public partial class InputNodeViewModel<T>: NodeVMBasekun,INodeViewModelBase
    {
        static InputNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<InputNodeViewModel<T>>));
        }
        /// <summary>
        /// Value Editor
        /// </summary>
        public HannyouValueEditorViewModel<T> ValueEditor { get; } = new HannyouValueEditorViewModel<T>();
        [ModelAyano]
        private InputNodeModel<T> _model = new InputNodeModel<T>();
        /// <summary>
        /// Output Value?
        /// </summary>
        public ValueNodeOutputViewModel<T?> Output { get; }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="newmodelbs"></param>

        public void ChangeStates(XML_NodeModel newmodelbs)
        {

            Name = newmodelbs.Name;
            Position = new System.Windows.Point
            {
                X = newmodelbs.Points.X,
                Y = newmodelbs.Points.Y
            };
            ValueEditor.Value = ((InputNodeModel<T>)newmodelbs).Value;
        }
        public InputNodeViewModel(Guid uuid) : base(uuid)
        {
            InitAyanoVMB();
            Output = new ValueNodeOutputViewModel<T?>
            {
                Name = "Value",
                Editor = ValueEditor,
                Value = this.WhenAnyValue(vm => vm.ValueEditor.Value)
            };
            InitConstructor();
        }
        public InputNodeViewModel() : base()
        {
            InitAyanoVMB();
            Output = new ValueNodeOutputViewModel<T?>
            {
                Name = "Value",
                Editor = ValueEditor,
                Value = this.WhenAnyValue(vm => vm.ValueEditor.Value)
            };
            InitConstructor();
        }
        private void InitConstructor()
        {
            this.ValueEditor.ValueChanged.Subscribe(newvalue =>
            {
                _model.Value = newvalue;
            });

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

            this.WhenAnyObservable(vm => vm.Output.Connections.CountChanged).Subscribe(newvalue =>
            {

                foreach (XMLNodeOutput xs in _model.Outputs.Where(d =>
                {
                    return d.Name == Output.Name;
                }))
                {
                    xs.connections.Clear();
                    foreach (ConnectionViewModel cv in Output.Connections.Items)
                    {
                        //Console.WriteLine($"{cv.Input.Name},{cv.Input.Parent.UUID}");
                        xs.connections.Add(
                            new XMLNodeOutputConnect
                            {
                                Name = cv.Input.Name,
                                Target = cv.Input.Parent.UUID
                            });
                    }
                }
            });
            this.Outputs.Add(Output);

        }

    }
}
