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
    /// <summary>
    /// Statement入出力を備えたNodeの基本形
    /// </summary>
    public class StatementNodeViewModelBase: NodeViewModel
    {

        static StatementNodeViewModelBase()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<StatementNodeViewModelBase>));
        }

        /// <summary>
        /// Input(表示上はOutput)
        /// </summary>
        public ValueListNodeInputViewModel<StatementCls> InputFlow { get; }
        /// <summary>
        /// Output(表示上はInput)
        /// </summary>
        public ValueNodeOutputViewModel<StatementCls> OutputFlow { get; }
        public StatementCls StatementIfce { get; }
        public IObservable<string> NameChanged { get; }
        public StatementNodeViewModelBase()
        {

            StatementIfce = StatementCls.GenStatementCls(this.UUID);
            OutputFlow = new ValueNodeOutputViewModel<StatementCls>
            {
                Name="In",
                MaxConnections = 1,
                Value= this.WhenAnyValue(vm => vm.StatementIfce),
                PortPosition = PortPosition.Left
            };
            InputFlow = new ValueListNodeInputViewModel<StatementCls>
            {
                Name = "Out",
                MaxConnections = 1,
                PortPosition=PortPosition.Right
            };
            this.Outputs.Add(OutputFlow);
            this.Inputs.Add(InputFlow);
            NameChanged = this.WhenAnyValue(vm => vm.Name);
        }
    }
}
