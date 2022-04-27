using DynamicData;
using FatNoder.Model.Transc;
using NodeAyano.Model.Nodes;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeNetworkJH.ViewModels;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels.Nodes
{
    public class MethodEntryPointVIewModel : NodeVMBasekun
    {

        static MethodEntryPointVIewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<MethodEntryPointVIewModel>));
        }

        public ValueListNodeInputViewModel<StatementCls> Input { get; }
        private MethodEntryPoint _model=new MethodEntryPoint();
        public MethodEntryPoint model
        {
            get
            {
                return _model;
            }
        }
        public MethodEntryPointVIewModel()
        {
            model.TYPE = typeof(MethodEntryPointVIewModel).ToString();

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
            Input = new CoderListInputViewModel<StatementCls>(typeof(StatementCls))
            {
                Name = "statement",
                PortPosition=PortPosition.Right,
                MaxConnections = 1
            };

            
            this.Inputs.Add(Input);
        }
    }
}
