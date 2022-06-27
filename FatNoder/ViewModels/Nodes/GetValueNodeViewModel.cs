using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels.Nodes
{
    public partial class GetValueNodeViewModel<T> : StatementNodeViewModelBase, INodeViewModelBase
    {
        static GetValueNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(()=>new NodeView(),typeof(IViewFor<GetValueNodeViewModel<T>>));
        }
    }
}
