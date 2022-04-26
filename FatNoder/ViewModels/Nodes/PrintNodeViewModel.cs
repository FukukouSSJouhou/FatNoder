using DynamicData;
using FatNoder.Serializer.Node.Xml;
using FatNoder.ViewModels.Xml;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels.Nodes
{
    public class PrintNodeViewModel : StatementNodeViewModelBase, INVModelXML
    {
        static PrintNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<PrintNodeViewModel>));
        }
        public ValueNodeInputViewModel<string?> PrintInput { get; }
        public PrintNodeViewModel()
        {

            PrintInput = new ValueNodeInputViewModel<string?>
            {
                Name = "Printcontent",
                Editor = new HannyouValueEditorViewModel<string?>(),
                MaxConnections = 1
            };
            PrintInput.ValueChanged.Subscribe(newvalue =>
            {
                Debug.Print("Set print : " + newvalue);
            });
            this.Inputs.Add(PrintInput);
        }

        public XmlNodeDatas GetXMLNodeDT()
        {
            return new XmlNodeDatas();
        }

        public void SetXMLNodeDT(XmlNodeDatas xmldt)
        {
            throw new NotImplementedException();
        }
    }
}
