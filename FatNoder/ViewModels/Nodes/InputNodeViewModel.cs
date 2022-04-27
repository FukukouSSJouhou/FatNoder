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
    /// 入力するNodeの基本形?
    /// </summary>
    /// <typeparam name="T">入力型</typeparam>
    public class InputNodeViewModel<T>: StatementNodeViewModelBase, INodeViewModelBase
    {
        static InputNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<InputNodeViewModel<T>>));
        }
        public HannyouValueEditorViewModel<T> ValueEditor { get; } = new HannyouValueEditorViewModel<T>();
        private InputNodeModel<T> _model = new InputNodeModel<T>(); 

        public XML_NodeModel model 
        {
            get
            {
                return _model;

            }
        }
        public ValueNodeOutputViewModel<T?> Output { get; }
        public InputNodeViewModel()
        {
            _model.TYPE = typeof(InputNodeModel<T>).ToString();
            Output = new ValueNodeOutputViewModel<T?> {
                Name = "Value",
                Editor = ValueEditor,
                Value = this.WhenAnyValue(vm => vm.ValueEditor.Value)
            };
            this.ValueEditor.ValueChanged.Subscribe(newvalue =>
            {
                _model.Value = newvalue;
            });
            this.UUIDChanged.Subscribe(newvalue =>
            {
                _model.UUID = newvalue;
            });
            this.NameChanged.Subscribe(newvalue =>
            {
                _model.Name = newvalue;
            });
            this.PositionChanged.Subscribe(newvalue =>
            {
                _model.Points = new XMLNodeXY()
                {
                    X = newvalue.X,
                    Y = newvalue.Y
                };
            });
            _model.InputStates = new XMLNodeInputStatement_VMLS
            {
                new XMLNodeInputStatement()
                {
                    States = new XMLNodeInputStatementLS(),
                    Name = InputFlow.Name
                }
            };
            this.WhenAnyObservable(vm => vm.InputFlow.Values.CountChanged).Subscribe(newvalue =>
            {
                foreach (XMLNodeInputStatement xs in _model.InputStates.Where(d =>
                {
                    return d.Name == InputFlow.Name;
                }))
                {
                    xs.States = new XMLNodeInputStatementLS();
                    foreach (StatementCls guidkun in InputFlow.Values.Items)
                    {
                        xs.States.Add(guidkun.UUID);
                    }
                }
            });
            this.Outputs.Add(Output);
        }

        
    }
}
