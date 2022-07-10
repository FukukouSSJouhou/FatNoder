using FatNoder.Views.Sentences.Editors;
using NodeAyano.Model.Nodes.Sentences;
using NodeNetworkJH.Toolkit.ValueNode;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels.Nodes.Sentences.Editors
{
    public class ConditionNodeTypeEditorViewModel : ValueEditorViewModel<ConditionParamTypeEnum?>
    {
        public Dictionary<ConditionParamTypeEnum, string> ConditionNodeTypeEnum { get; } = new Dictionary<ConditionParamTypeEnum, string>();
        static ConditionNodeTypeEditorViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new ConditionNodeTypeEditorView(), typeof(IViewFor<ConditionNodeTypeEditorViewModel>));
        }
        public int selectedIndexView { get; set; } = 0;
        public ConditionNodeTypeEditorViewModel()
        {
            Value = ConditionParamTypeEnum.Equals;
            ConditionNodeTypeEnum.Add(ConditionParamTypeEnum.Equals, "==");
            ConditionNodeTypeEnum.Add(ConditionParamTypeEnum.NotEquals, "!=");
            ConditionNodeTypeEnum.Add(ConditionParamTypeEnum.GreaterThan, "<");
            ConditionNodeTypeEnum.Add(ConditionParamTypeEnum.GreaterThanOrEqual, "<=");
            ConditionNodeTypeEnum.Add(ConditionParamTypeEnum.LessThan, ">");
            ConditionNodeTypeEnum.Add(ConditionParamTypeEnum.LessThanOrEqual, ">=");
        }
        public void SelectViewKun(ConditionParamTypeEnum indexkun)
        {
            switch (indexkun)
            {
                case ConditionParamTypeEnum.Equals:
                    selectedIndexView = 0;
                    break;
                case ConditionParamTypeEnum.NotEquals:
                    selectedIndexView = 1;
                    break;
                case ConditionParamTypeEnum.GreaterThan:
                    selectedIndexView = 2;
                    break;
                case ConditionParamTypeEnum.GreaterThanOrEqual:
                    selectedIndexView = 3;
                    break;
                case ConditionParamTypeEnum.LessThan:
                    selectedIndexView = 4;
                    break;
                case ConditionParamTypeEnum.LessThanOrEqual:
                    selectedIndexView = 5;
                    break;
            }
        }

    }
}
