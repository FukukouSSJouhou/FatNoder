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

namespace FatNoder.ViewModels.Nodes
{
    public partial class SetValueNodeViewModel<T> : StatementNodeViewModelBase, INodeViewModelBase
    {
        static SetValueNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<SetValueNodeViewModel<T>>));
        }
        [ModelAyano]
        private SetValueNodeModel<T> _model = new SetValueNodeModel<T>();
        public SetValueNodeViewModel(Guid uuid) : base(uuid)
        {
            InitAyanoVMB();
        }
        public SetValueNodeViewModel() : base()
        {
            InitAyanoVMB();
        }
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
