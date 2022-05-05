using DynamicData;
using FatNoder.Model.Transc;
using FatNoder.Serializer.Node.Xml;
using NodeAyano.Model.Nodes;
using NodeAyanoVMLibs.ViewModels.Nodes;
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
    public class PrintNodeViewModel : StatementNodeViewModelBase, INodeViewModelBase
    {
        static PrintNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<PrintNodeViewModel>));
        }
        
        public ValueNodeInputViewModel<string?> PrintInput { get; }
        private PrintNodeModel _model = new PrintNodeModel();
        public XML_NodeModel model
        {
            get
            {
                return _model;
            }
        }
        public PrintNodeViewModel(Guid UUID):base(UUID)
        {
            model.TYPE = typeof(PrintNodeViewModel).AssemblyQualifiedName;
            _model.MODELTYPE = typeof(PrintNodeModel).AssemblyQualifiedName;
            PrintInput = new ValueNodeInputViewModel<string?>
            {
                Name = "Printcontent",
                Editor = new HannyouValueEditorViewModel<string?>(),
                MaxConnections = 1
            };
            PrintInput.ValueChanged.Subscribe(newvalue =>
            {
                _model.Value = newvalue;
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
            this.PrintInput.Connections.CountChanged.Subscribe(newvalue =>
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
            this.Inputs.Add(PrintInput);
        }

        public PrintNodeViewModel()
        {
            model.TYPE = typeof(PrintNodeViewModel).AssemblyQualifiedName;
            _model.MODELTYPE = typeof(PrintNodeModel).AssemblyQualifiedName;
            PrintInput = new ValueNodeInputViewModel<string?>
            {
                Name = "Printcontent",
                Editor = new HannyouValueEditorViewModel<string?>(),
                MaxConnections = 1
            };
            PrintInput.ValueChanged.Subscribe(newvalue =>
            {
                _model.Value = newvalue;
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
            this.PrintInput.Connections.CountChanged.Subscribe(newvalue =>
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
            this.Inputs.Add(PrintInput);
        }

        public void ChangeStates(XML_NodeModel newmodelbs)
        {

            Name = newmodelbs.Name;
            Position = new System.Windows.Point
            {
                X = newmodelbs.Points.X,
                Y = newmodelbs.Points.Y
            };
            _model.Value = ((PrintNodeModel)newmodelbs).Value;
        }
    }
}
