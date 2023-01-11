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
    public partial class ForNodeViewModel:StatementNodeViewModelBase,INodeViewModelBase
    {
        static ForNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ForNodeViewModel>));
        }
        [ModelAyano]
        private ForNodeModel _model = new ForNodeModel();
    }
}
