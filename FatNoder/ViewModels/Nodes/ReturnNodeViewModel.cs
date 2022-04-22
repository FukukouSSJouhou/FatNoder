using DynamicData;
using FatNoder.Model.TransC;
using NodeNetwork.Toolkit.ValueNode;
using NodeNetwork.ViewModels;
using NodeNetwork.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public ValueListNodeInputViewModel<IStateMent> Flow { get; }
        public ReturnNodeViewModel()
        {
            ReturnInput = new ValueNodeInputViewModel<T?>
            {
                Name = "Value",
                Editor=new HannyouValueEditorViewModel<T?>()
            };
            ReturnInput.ValueChanged.Subscribe(newvalue =>
            {
                Debug.Print("Set : " + newvalue);
            });
            this.Inputs.Add(ReturnInput);
            Flow = new CoderListInputViewModel<IStateMent>(typeof(IStateMent))
            {
                Name = ""
            };
            this.Inputs.Add(Flow);
        }
    }
}
