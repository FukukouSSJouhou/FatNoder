using DynamicData;
using FatNoder.Serializer.Node.Xml;
using FatNoder.ViewModels.Xml;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeNetworkJH.ViewModels;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels.Nodes
{
    public class InputNodeViewModel<T>: StatementNodeViewModelBase, INVModelXML
    {
        [DataContract(Name = "Datas")]
        public class InputNodeViewModelNaibuSyoriXML : XmlNodeDatas
        {
            [DataMember (Name ="Value",Order =1)]
            public string Value
            {
                get;set;
            }
        }
        static InputNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<InputNodeViewModel<T>>));
        }
        public HannyouValueEditorViewModel<T> ValueEditor { get; } = new HannyouValueEditorViewModel<T>();
        public ValueNodeOutputViewModel<T?> Output { get; }
        public InputNodeViewModel()
        {
            Output = new ValueNodeOutputViewModel<T?> {
                Name = "Value",
                Editor = ValueEditor,
                Value = this.WhenAnyValue(vm => vm.ValueEditor.Value)
            };
            this.Outputs.Add(Output);
        }

        public XmlNodeDatas GetXMLNodeDT()
        {
            InputNodeViewModelNaibuSyoriXML nvkun = new();
            nvkun.Value = this.ValueEditor.Value.ToString();
            return nvkun;
        }

        public void SetXMLNodeDT(XmlNodeDatas xmldt)
        {
            throw new NotImplementedException();
        }
    }
}
