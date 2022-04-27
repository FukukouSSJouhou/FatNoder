using DynamicData;
using FatNoder.Model.Transc;
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
    public class MethodEntryPointVIewModel : NodeVMBasekun
    {

        static MethodEntryPointVIewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<MethodEntryPointVIewModel>));
        }

        public ValueListNodeInputViewModel<StatementCls> Input { get; }
        public MethodEntryPointVIewModel()
        {

            Input = new CoderListInputViewModel<StatementCls>(typeof(StatementCls))
            {
                Name = "statement",
                PortPosition=PortPosition.Right,
                MaxConnections = 1
            };
            
            this.Inputs.Add(Input);
        }
    }
}
