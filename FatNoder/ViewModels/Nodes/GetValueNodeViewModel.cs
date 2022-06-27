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
using FatNoder.Serializer.Node.Xml;

namespace FatNoder.ViewModels.Nodes
{
    public partial class GetValueNodeViewModel<T> : StatementNodeViewModelBase, INodeViewModelBase
    {
        static GetValueNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(()=>new NodeView(),typeof(IViewFor<GetValueNodeViewModel<T>>));
        }
        [ModelAyano]
        private GetValueNodeModel<T> _model = new GetValueNodeModel<T>();
        ///<inheritdoc/>
        public GetValueNodeViewModel(Guid uuid) : base(uuid)
        {
            InitAyanoVMB();
        }
        ///<inheritdoc/>
        public GetValueNodeViewModel() : base()
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
            _model.ValueName = ((SetValueNodeModel<T>)newmodelbs).ValueName;
            ((HannyouValueEditorViewModel<string>)NameInput.Editor).Value = _model.ValueName;
        }
    }
}
