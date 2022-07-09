using NodeAyano.Model.Nodes.Sentences;
using NodeNetworkJH.Toolkit.ValueNode;
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

        public int selectedIndexView { get; set; } = 0;



    }
}
