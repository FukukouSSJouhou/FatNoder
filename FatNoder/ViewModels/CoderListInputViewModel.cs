using FatNoder.Model.Transc;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels
{
    public class CoderListInputViewModel<T>: ValueListNodeInputViewModel<T>
    {

        static CoderListInputViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeInputView(), typeof(IViewFor<CoderListInputViewModel<T>>));
        }
        public CoderListInputViewModel(Type type)
        {
            if (type == typeof(StatementCls))
            {
                this.PortPosition = NodeNetworkJH.ViewModels.PortPosition.Right;
            }
        }
    }
}
