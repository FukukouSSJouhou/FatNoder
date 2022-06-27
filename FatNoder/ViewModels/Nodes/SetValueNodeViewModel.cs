using FatNoder.Views;
using NodeAyano.Model.Nodes;
using NodeAyanoVMLibs.ViewModels.Nodes;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AyanoNodeVM;
using FatNoder.Serializer.Node.Xml;
using NodeNetworkJH.Toolkit.ValueNode;

namespace FatNoder.ViewModels.Nodes
{
    public partial class SetValueNodeViewModel<T> : StatementNodeViewModelBase, INodeViewModelBase
    {
        static SetValueNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<SetValueNodeViewModel<T>>));
        }
        public ValueNodeInputViewModel<T?> HensuuInput { get; }
        [ModelAyano]
        private SetValueNodeModel<T> _model = new SetValueNodeModel<T>();
        ///<inheritdoc/>
        public SetValueNodeViewModel(Guid uuid) : base(uuid)
        {
            InitAyanoVMB();
        }
        ///<inheritdoc/>
        public SetValueNodeViewModel() : base()
        {
            InitAyanoVMB();
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
        }
    }
}
