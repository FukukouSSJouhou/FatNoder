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
    public class CoderOutputViewModel<T> : ValueNodeOutputViewModel<T>
    {
        static CoderOutputViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeOutputView(), typeof(IViewFor<CoderOutputViewModel<T>>));
        }
        public CoderOutputViewModel(Type StructData)
        {
            if (StructData == typeof(StatementCls))
            {
                this.PortPosition = NodeNetworkJH.ViewModels.PortPosition.Right;
            }
        }
    }
}