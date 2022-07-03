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
        public ValueEnzannEngineTypeEditorViewModel()
        {
            Value = ValueEnzannEngineType.Add;
            ValueEnzannEngineEnum.Add(ValueEnzannEngineType.Add, "Add");
            ValueEnzannEngineEnum.Add(ValueEnzannEngineType.Divide, "Divide");
            ValueEnzannEngineEnum.Add(ValueEnzannEngineType.Multiply, "Multiply");
        }
    }
}
