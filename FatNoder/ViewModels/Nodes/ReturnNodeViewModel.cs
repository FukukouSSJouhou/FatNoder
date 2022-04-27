using DynamicData;
using FatNoder.Model.Transc;
using FatNoder.Serializer.Node.Xml;
using NodeAyano.Model.Nodes;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeNetworkJH.ViewModels;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels.Nodes
{
    /// <summary>
    /// 値を返却するNodeの基本形
    /// </summary>
    /// <typeparam name="T">型</typeparam>
    public class ReturnNodeViewModel<T> : NodeViewModel, INodeViewModelBase
    {
        
        static ReturnNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ReturnNodeViewModel<T>>));

        }
        public ValueNodeInputViewModel<T?> ReturnInput { get; }
        public ValueNodeOutputViewModel<StatementCls> Flow { get; }
        public StatementCls StatementIfce { get; }
        private ReturnNodeModel<T> _model = new ReturnNodeModel<T>();
        public XML_NodeModel model
        {
            get
            {
                return _model;
            }
        }
        public ReturnNodeViewModel()
        {

            StatementIfce = StatementCls.GenStatementCls(this.UUID);
            ReturnInput = new ValueNodeInputViewModel<T?>
            {
                Name = "ValueRet",
                Editor=new HannyouValueEditorViewModel<T?>(),
                MaxConnections=1
            };
            ReturnInput.ValueChanged.Subscribe(newvalue =>
            {
                _model.Value = newvalue;
            });
            Flow = new ValueNodeOutputViewModel<StatementCls>
            {
                Name = "In",
                MaxConnections = 1,
                Value = this.WhenAnyValue(vm =>vm.StatementIfce),
                PortPosition=PortPosition.Left
            };
            this.Outputs.Add(Flow);
            this.Inputs.Add(ReturnInput);
        }
    }
}
