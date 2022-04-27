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
    public class InputNodeViewModel<T>: StatementNodeViewModelBase
    {
        static InputNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<InputNodeViewModel<T>>));
        }
        public HannyouValueEditorViewModel<T> ValueEditor { get; } = new HannyouValueEditorViewModel<T>();
        private InputNodeModel<T> _model = new InputNodeModel<T>(); 

        public InputNodeModel<T> model 
        {
            get
            {
                return _model;

            }
        }
        public ValueNodeOutputViewModel<T?> Output { get; }
        public InputNodeViewModel()
        {
            model.TYPE = typeof(InputNodeModel<T>).ToString();
            Output = new ValueNodeOutputViewModel<T?> {
                Name = "Value",
                Editor = ValueEditor,
                Value = this.WhenAnyValue(vm => vm.ValueEditor.Value)
            };
            this.ValueEditor.ValueChanged.Subscribe(newvalue =>
            {
                model.Value = newvalue;
            });
            this.UUIDChanged.Subscribe(newvalue =>
            {
                model.UUID = newvalue;
            });
            this.NameChanged.Subscribe(newvalue =>
            {
                model.Name = newvalue;
            });
            this.PositionChanged.Subscribe(newvalue =>
            {
                model.Points = new XMLNodeXY()
                {
                    X = newvalue.X,
                    Y = newvalue.Y
                };
            });
            model.InputStates = new XMLNodeInputStatement_VMLS();
            model.InputStates.Add(new XMLNodeInputStatement()
            {
                States = new XMLNodeInputStatementLS(),
                Name = InputFlow.Name
            });
            this.WhenAnyObservable(vm => vm.InputFlow.Values.CountChanged).Subscribe(newvalue =>
            {
                foreach (XMLNodeInputStatement xs in model.InputStates.Where(d =>
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
