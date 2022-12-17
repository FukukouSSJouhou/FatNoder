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
using ControlzEx.Standard;
using FatNoder.Model.Transc;
using FatNoder.ViewModels.Ports;
using NodeNetworkJH.ViewModels;

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
        /// <summary>
        /// constructor
        /// </summary>
        public HttpClientPostDataNodeViewModel() : base()
        {
            InitAyanoVMB();
            InputURL = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "URL_INPUT",
                Label ="URL",
                MaxConnections = 1
            };
            Initkun();
        }
        /// <summary>
        /// constructor
        /// </summary>
        public HttpClientPostDataNodeViewModel(Guid uuid) : base(uuid)
        {
            InitAyanoVMB();
            InputURL = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "URL_INPUT",
                Label = "URL",
                MaxConnections = 1
            };
            Initkun();
        }
        /// <inheritdoc/>

        public void ChangeStates(XML_NodeModel newmodelbs)
        {

            Name = "HTTP_NODE";
            Position = new System.Windows.Point
            {
                X = newmodelbs.Points.X,
                Y = newmodelbs.Points.Y
            };
            _model.Value = ((HttpClientPostDataNodeModel)newmodelbs).Value;
        }
        public void Initkun()
        {

            _model.Inputs = new XMLNodeInputS
            {
                new XMLNodeInput()
                {
                    Name = InputURL.Name,
                    connections=new XMLNodeInputConnectS
                    {

                    }
                }
            };
            _model.InputStates = new XMLNodeInputStatement_VMLS();
            _model.InputStates.Add(new XMLNodeInputStatement()
            {
                States = new XMLNodeInputStatementLS(),
                Name = InputFlow.Name
            });
            this.WhenAnyObservable(vm => vm.InputFlow.Values.CountChanged).Subscribe(newvalue =>
            {
                foreach (XMLNodeInputStatement xs in _model.InputStates.Where(d =>
                {
                    return d.Name == InputFlow.Name;
                }))
                {
                    xs.States.Clear();
                    foreach (StatementCls guidkun in InputFlow.Values.Items)
                    {
                        xs.States.Add(guidkun.UUID);
                    }
                }
            });
            InputURL.Connections.CountChanged.Subscribe(newvalue =>
            {

                foreach (XMLNodeInput xs in _model.Inputs.Where(d =>
                {
                    return d.Name == InputURL.Name;
                }))
                {
                    xs.connections.Clear();
                    foreach (ConnectionViewModel cv in InputURL.Connections.Items)
                    {
                        //Console.WriteLine($"{cv.Input.Name},{cv.Input.Parent.UUID}");
                        xs.connections.Add(
                            new XMLNodeInputConnect
                            {
                                Name = cv.Output.Name,
                                Target = cv.Output.Parent.UUID,
                                InputOnly = false
                            });
                    }
                }
            });
            this.Inputs.Add(InputURL);
            InputFlow.Port = new NodePortViewModel
            {
                Node_PortType = PortType.Statement
            };
            OutputFlow.Port = new NodePortViewModel
            {
                Node_PortType = PortType.Statement
            };
        }
    }
}
