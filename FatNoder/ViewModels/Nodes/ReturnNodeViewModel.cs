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
    public class ReturnNodeViewModel<T> : NodeVMBasekun, INodeViewModelBase
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
        public ReturnNodeViewModel(Guid UUID):base(UUID)
        {
            model.TYPE = typeof(ReturnNodeViewModel<T>).AssemblyQualifiedName;
            model.MODELTYPE = typeof(ReturnNodeModel<T>).AssemblyQualifiedName;

            StatementIfce = StatementCls.GenStatementCls(this.UUID);
            ReturnInput = new ValueNodeInputViewModel<T?>
            {
                Name = "ValueRet",
                Editor = new HannyouValueEditorViewModel<T?>(),
                MaxConnections = 1
            };
            ReturnInput.ValueChanged.Subscribe(newvalue =>
            {
                _model.Value = newvalue;
            });
            Flow = new ValueNodeOutputViewModel<StatementCls>
            {
                Name = "In",
                MaxConnections = 1,
                Value = this.WhenAnyValue(vm => vm.StatementIfce),
                PortPosition = PortPosition.Left
            };
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
            this.ReturnInput.Connections.CountChanged.Subscribe(newvalue =>
            {
                if (newvalue > 0)
                {
                    _model.Isconnected = true;
                }
                else
                {

                    _model.Isconnected = false;
                }
            }
            );
            model.InputStates = new XMLNodeInputStatement_VMLS();
            model.InputStates.Add(new XMLNodeInputStatement());
            this.Inputs.Add(ReturnInput);
            this.Outputs.Add(Flow);
        }
        public ReturnNodeViewModel()
        {
            model.TYPE = typeof(ReturnNodeViewModel<T>).AssemblyQualifiedName;
            model.MODELTYPE=typeof(ReturnNodeModel<T>).AssemblyQualifiedName;

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
            this.ReturnInput.Connections.CountChanged.Subscribe(newvalue =>
            {
                if(newvalue > 0)
                {
                    _model.Isconnected = true;
                }
                else
                {

                    _model.Isconnected = false;
                }
            }
            );
            model.InputStates = new XMLNodeInputStatement_VMLS();
            model.InputStates.Add(new XMLNodeInputStatement());
            this.Inputs.Add(ReturnInput);
            this.Outputs.Add(Flow);
        }
        public void ChangeStates(XML_NodeModel newmodelbs)
        {

            Name = newmodelbs.Name;
            Position = new System.Windows.Point
            {
                X = newmodelbs.Points.X,
                Y = newmodelbs.Points.Y
            };
            _model.Value = ((ReturnNodeModel<T>)newmodelbs).Value;
        }
    }
}
