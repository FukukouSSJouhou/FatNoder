using FatNoder.Model.TransC;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.Views;
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
            if (type == typeof(IStateMent))
            {
                this.PortPosition = NodeNetwork.ViewModels.PortPosition.Right;
            }
        }
    }
}
