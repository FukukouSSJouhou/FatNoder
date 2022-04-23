using NodeNetworkJH.ViewModels;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels.Nodes
{
    public class NodeIEnumerableViewModel<T>: IncluedUUIDNodeViewModel
    {

        static NodeIEnumerableViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<NodeIEnumerableViewModel<T>>));

        }

    }
}
