using DynamicData;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels.Nodes
{
    public class ReturnNodeViewModel<T> : NodeViewModel
    {
        static ReturnNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ReturnNodeViewModel<T>>));

        }
        public ValueNodeInputViewModel<T?> ReturnInput { get; }
        public ReturnNodeViewModel()
        {
            this.CanBeRemovedByUser = false;
            ReturnInput = new ValueNodeInputViewModel<T?>
            {
                Name = "Value",
                Editor=new HannyouValueEditorViewModel<T?>()
            };
            this.Inputs.Add(ReturnInput);
        }
    }
}
