using DynamicData;
using FatNoder.Model.TransC;
using NodeNetworkJH.Toolkit.ValueNode;
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
    public class MethodEntryPointVIewModel : NodeViewModel, IStateMent
    {

        public NodeViewModel ChiNode()
        {
            return this;
        }
        static MethodEntryPointVIewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<MethodEntryPointVIewModel>));
        }

        public ValueListNodeInputViewModel<IStateMent> Input { get; }
        public MethodEntryPointVIewModel()
        {

            Input = new CoderListInputViewModel<IStateMent>(typeof(IStateMent))
            {
                Name = "statement",
                PortPosition=PortPosition.Right,
                MaxConnections = 1
            };
            
            this.Inputs.Add(Input);
        }
    }
}
