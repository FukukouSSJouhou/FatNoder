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
    public class CoderOutputViewModel<T> : ValueNodeOutputViewModel<T>
    {
        static CoderOutputViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeOutputView(), typeof(IViewFor<CoderOutputViewModel<T>>));
        }
        public CoderOutputViewModel(Type StructData)
        {
            if (StructData == typeof(IStateMent))
            {
                this.PortPosition = NodeNetwork.ViewModels.PortPosition.Left;
            }
        }
    }
}