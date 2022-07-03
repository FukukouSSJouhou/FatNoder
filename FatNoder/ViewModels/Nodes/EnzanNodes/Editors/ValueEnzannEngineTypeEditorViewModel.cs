using FatNoder.Views.EnzanNodes;
using NodeAyano.Model.Nodes.ValueEnzann;
using NodeNetworkJH.Toolkit.ValueNode;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels.Nodes.EnzanNodes.Editors
{
    public class ValueEnzannEngineTypeEditorViewModel: ValueEditorViewModel<ValueEnzannEngineType?>
    {
        public Dictionary<ValueEnzannEngineType, string> ValueEnzannEngineEnum { get; } = new Dictionary<ValueEnzannEngineType, string>();

        static ValueEnzannEngineTypeEditorViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new ValueEnzannEngineTypeEditorView(), typeof(IViewFor<ValueEnzannEngineTypeEditorViewModel>));
        }
        public int selectedIndexView { get; set; } = 0;
        /// <summary>
        /// Value Enzann Type View Model Editor!!!
        /// </summary>
        public ValueEnzannEngineTypeEditorViewModel()
        {
            Value = ValueEnzannEngineType.Add;
            ValueEnzannEngineEnum.Add(ValueEnzannEngineType.Add, Properties.Resources.ValueEnzannEngineTypeEditorViewModel_ADD);
            ValueEnzannEngineEnum.Add(ValueEnzannEngineType.Subtract, Properties.Resources.ValueEnzannEngineTypeEditorViewModel_Subtract);
            ValueEnzannEngineEnum.Add(ValueEnzannEngineType.Divide, Properties.Resources.ValueEnzannEngineTypeEditorViewModel_Divide);
            ValueEnzannEngineEnum.Add(ValueEnzannEngineType.Multiply, Properties.Resources.ValueEnzannEngineTypeEditorViewModel_Multiply);
        }
        public void SelectViewKun(ValueEnzannEngineType indexkun)
        {
            switch (indexkun)
            {
                case ValueEnzannEngineType.Add:
                    selectedIndexView = 0;
                    break;
                case ValueEnzannEngineType.Subtract:
                    selectedIndexView = 1;
                    break;
                case ValueEnzannEngineType.Divide:
                    selectedIndexView = 2;
                    break;
                case ValueEnzannEngineType.Multiply:
                    selectedIndexView = 3;
                    break;

            }
        }
    }
}
