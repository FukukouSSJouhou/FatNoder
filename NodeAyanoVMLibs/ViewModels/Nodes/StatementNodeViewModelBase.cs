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
using System.Windows;

namespace NodeAyanoVMLibs.ViewModels.Nodes
{
    /// <summary>
    /// Statement入出力を備えたNodeの基本形
    /// </summary>
    public class StatementNodeViewModelBase: NodeVMBasekun
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
        /// <summary>
        /// Constructor (Set UUID)
        /// </summary>
        /// <param name="UUID">UUID</param>
        public StatementNodeViewModelBase(Guid UUID):base(UUID)
        {

            StatementIfce = StatementCls.GenStatementCls(this.UUID);
            OutputFlow = new ValueNodeOutputViewModel<StatementCls>
            {
                Name = "In",
                Label="In",
                MaxConnections = 1,
                Value = this.WhenAnyValue(vm => vm.StatementIfce),
                PortPosition = PortPosition.Left
            };
            InputFlow = new ValueListNodeInputViewModel<StatementCls>
            {
                Name = "Out",
                Label="Out",
                MaxConnections = 1,
                PortPosition = PortPosition.Right
            };
            this.Outputs.Add(OutputFlow);
            this.Inputs.Add(InputFlow);
        }
        /// <summary>
        /// constructor
        /// </summary>
        public StatementNodeViewModelBase()
        {

            StatementIfce = StatementCls.GenStatementCls(this.UUID);
            OutputFlow = new ValueNodeOutputViewModel<StatementCls>
            {
                Name="In",
                Label="In",
                MaxConnections = 1,
                Value= this.WhenAnyValue(vm => vm.StatementIfce),
                PortPosition = PortPosition.Left
            };
            InputFlow = new ValueListNodeInputViewModel<StatementCls>
            {
                Name = "Out",
                Label="Out",
                MaxConnections = 1,
                PortPosition=PortPosition.Right
            };
            this.Outputs.Add(OutputFlow);
            this.Inputs.Add(InputFlow);
        }
    }
}
