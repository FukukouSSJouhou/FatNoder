using NodeAyano.Model.Nodes.Sentences;
using NodeAyanoVMLibs.ViewModels.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AyanoNodeVM;
using NodeNetworkJH.Views;
using ReactiveUI;
using NodeAyano.HensuuV;
using NodeNetworkJH.Toolkit.ValueNode;

namespace FatNoder.ViewModels.Nodes.Sentences
{
    public partial class ConditionNodeViewModel : NodeVMBasekun, INodeViewModelBase
    {

        [ModelAyano]
        private ConditionNodeModel _model = new ConditionNodeModel();
        static ConditionNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ConditionNodeViewModel>));
        }
        /// <summary>
        /// Output Value?
        /// </summary>
        public ValueNodeOutputViewModel<HensuuUkewatashi?> Output { get; }
        private HensuuUkewatashi hkun = new HensuuUkewatashi();
        public ValueNodeInputViewModel<HensuuUkewatashi?> Input1 { get; }

        public ValueNodeInputViewModel<HensuuUkewatashi?> Input2 { get; }
        public ValueNodeInputViewModel<ConditionParamTypeEnum?> ConditionTypeInput { get; }

    }
}
