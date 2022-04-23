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
    public class StatementNodeViewModelBase: NodeViewModel
    {

        static StatementNodeViewModelBase()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<StatementNodeViewModelBase>));
        }

        public ValueListNodeInputViewModel<IStateMent> InputFlow { get; }
        public ValueNodeOutputViewModel<IStateMent> OutputFlow { get; }
        public StatementNodeViewModelBase()
        {
            OutputFlow = new ValueNodeOutputViewModel<IStateMent>
            {
                Name="Out",
                MaxConnections = 1
            };
            InputFlow = new ValueListNodeInputViewModel<IStateMent>
            {
                Name = "In",
                MaxConnections = 1
            };
            this.Outputs.Add(OutputFlow);
            this.Inputs.Add(InputFlow);
        }
    }
}
