using DynamicData;
using FatNoder.Model.TransC;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeNetworkJH.ViewModels;
using NodeNetworkJH.Views;
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
        public ValueNodeOutputViewModel<IStateMent> Flow { get; }
        public ReturnNodeViewModel()
        {
            ReturnInput = new ValueNodeInputViewModel<T?>
            {
                Name = "Value",
                Editor=new HannyouValueEditorViewModel<T?>(),
                MaxConnections=1
            };
            ReturnInput.ValueChanged.Subscribe(newvalue =>
            {
                Debug.Print("Set : " + newvalue);
            });
            this.Inputs.Add(ReturnInput);
            Flow = new ValueNodeOutputViewModel<IStateMent>
            {
                Name = "",
                MaxConnections = 1,
                PortPosition=PortPosition.Left
            };
            this.Outputs.Add(Flow);
        }
    }
}
