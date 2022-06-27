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
    }
}
