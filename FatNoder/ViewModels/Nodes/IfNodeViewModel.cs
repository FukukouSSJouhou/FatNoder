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
using NodeNetworkJH.Toolkit.ValueNode;
using NodeAyano.HensuuV;

namespace FatNoder.ViewModels.Nodes
{
    public class IfNodeViewModel : NodeVMBasekun, INodeViewModelBase
    {
        public ValueNodeInputViewModel<HensuuUkewatashi?> InputX { get; }
        static IfNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<IfNodeViewModel>));
        }
        [ModelAyano]
        private IfNodeModel _model = new IfNodeModel();
        public IfNodeViewModel(Guid uuid) : base(uuid)
        {
            InitAyanoVMB();
        }
        public IfNodeViewModel() : base()
        {
            InitAyanoVMB();
        }
    }
}
