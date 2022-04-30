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
            _model.TYPE = typeof(InputNodeViewModel<T>).AssemblyQualifiedName;
            _model.MODELTYPE = typeof(InputNodeModel<T>).AssemblyQualifiedName;
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
            _model.Outputs = new XMLNodeOutputS
            {
                new XMLNodeOutput()
                {
                    Name = Output.Name,
                    connections=new XMLNodeOutputConnectS
                    {

                    }
                }
            };
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
            this.WhenAnyObservable(vm => vm.Output.Connections.CountChanged).Subscribe(newvalue =>
            {

                foreach (XMLNodeOutput xs in _model.Outputs.Where(d =>
                {
                    return d.Name == Output.Name;
                }))
                {
                    xs.connections.Clear();
                    foreach (ConnectionViewModel cv in Output.Connections.Items)
                    {
                        //Console.WriteLine($"{cv.Input.Name},{cv.Input.Parent.UUID}");
                        xs.connections.Add(
                            new XMLNodeOutputConnect
                            {
                                Name=cv.Input.Name,
                                Target=cv.Input.Parent.UUID
                            });
                    }
                }
            });
            this.Outputs.Add(Output);
        }
        public void ChangeStates(XML_NodeModel newmodelbs)
        {

            model.UUID = newmodelbs.UUID;
            model.Name = newmodelbs.Name;
            model.Points = newmodelbs.Points;
            _model.Value = ((InputNodeModel<T>)newmodelbs).Value;
        }


    }
}
