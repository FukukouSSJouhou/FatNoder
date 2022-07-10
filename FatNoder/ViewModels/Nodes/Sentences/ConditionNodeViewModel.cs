using NodeAyano.Model.Nodes.Sentences;
using NodeAyanoVMLibs.ViewModels.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AyanoNodeVM;
using FatNoder.ViewModels.Nodes.EnzanNodes;
using NodeNetworkJH.Views;
using ReactiveUI;

namespace FatNoder.ViewModels.Nodes.Sentences
{
    public partial class ConditionNodeViewModel : NodeVMBasekun, INodeViewModelBase
    {

        [ModelAyano]
        private ConditionNodeModel _model = new ConditionNodeModel();
        static ConditionNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ConditionNodeViewModel>));
        }
    }
}
