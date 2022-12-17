using FatNoder.Serializer.Node.Xml;
using NodeAyano.HensuuV;
using NodeAyano.Model.Nodes;
using NodeAyano.Model.Nodes.Http;
using NodeAyanoVMLibs.ViewModels.Nodes;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeNetworkJH.Views;
using ReactiveUI;
using DynamicData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels.Nodes.Http
{
    public partial class HttpClientPostDataNodeViewModel : StatementNodeViewModelBase, INodeViewModelBase
    {

        private HttpClientPostDataNodeModel _model = new HttpClientPostDataNodeModel();
        public ValueNodeInputViewModel<HensuuUkewatashi?> InputURL {get;}
        static HttpClientPostDataNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<HttpClientPostDataNodeViewModel>));
        }
        /// <inheritdoc/>

        public void ChangeStates(XML_NodeModel newmodelbs)
        {

            Name = "HTTP NODE";
            Position = new System.Windows.Point
            {
                X = newmodelbs.Points.X,
                Y = newmodelbs.Points.Y
            };
            _model.Value = ((HttpClientPostDataNodeModel)newmodelbs).Value;
        }
    }
}
