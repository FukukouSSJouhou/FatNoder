using DynamicData;
using FatNoder.Model.TransC;
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
    public class MethodEntryPointVIewModel : IncluedUUIDNodeViewModel, IStateMent
    {

        public NodeViewModel ChiNode()
        {
            return this;
        }
        static MethodEntryPointVIewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<MethodEntryPointVIewModel>));
        }

        public ValueNodeOutputViewModel<IStateMent> Output { get; }
        public MethodEntryPointVIewModel()
        {

            Output = new ValueNodeOutputViewModel<IStateMent>
            {
                Name = "statement",

                MaxConnections = 1
            };
            
            this.Outputs.Add(Output);
        }
    }
}
