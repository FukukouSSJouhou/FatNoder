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

namespace FatNoder.ViewModels.Nodes
{
    public partial class InputNodeViewModel<T>: NodeVMBasekun,INodeViewModelBase
    {
        static InputNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<InputNodeViewModel<T>>));
        }
        public HannyouValueEditorViewModel<T> ValueEditor { get; } = new HannyouValueEditorViewModel<T>();
        [ModelAyano]
        private InputNodeModel<T> _model = new InputNodeModel<T>();
        public ValueNodeOutputViewModel<T?> Output { get; }

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

    }
}
