using NodeAyano.Model.Nodes;
using NodeAyanoVMLibs.ViewModels.Nodes;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AyanoNodeVM;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeAyano.HensuuV;
using FatNoder.Model.Transc;

namespace FatNoder.ViewModels.Nodes
{
    public partial class ForNodeViewModel:StatementNodeViewModelBase,INodeViewModelBase
    {
        private ValueNodeInputViewModel<HensuuUkewatashi?> Condition { get; }
        public ValueListNodeInputViewModel<StatementCls> DefineFor { get; }
        public ValueListNodeInputViewModel<StatementCls> OutFor { get; }
        static ForNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ForNodeViewModel>));
        }
        [ModelAyano]
        private ForNodeModel _model = new ForNodeModel();
    }
}
