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
using NodeAyano.HensuuV;

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
        public ValueNodeOutputViewModel<HensuuUkewatashi?> Output { get; }
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
            _model.InputOnly = true;
            Output = new ValueNodeOutputViewModel<HensuuUkewatashi?>
            {
                Name = "Value",
                Editor = ValueEditor,
                Value = this.WhenAnyValue(vm=>new HensuuUkewatashi(typeof(T)))
            };
            InitConstructor();
        }
        public InputNodeViewModel() : base()
        {
            InitAyanoVMB();
            _model.InputOnly = true;
            Output = new ValueNodeOutputViewModel<HensuuUkewatashi?>
            {
                Name = "Value",
                Editor = ValueEditor,
                Value = this.WhenAnyValue(vm => new HensuuUkewatashi(typeof(T)))
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

            this.Outputs.Add(Output);

        }

    }
}
