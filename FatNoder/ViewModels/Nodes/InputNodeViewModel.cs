using DynamicData;
using FatNoder.Serializer.Node.Xml;
using NodeAyano.Model.Nodes;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeNetworkJH.ViewModels;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
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
        public void SetV()
        {

            model.Name = this.Name;
            model.TYPE = typeof(InputNodeModel<T>).ToString();
            model.UUID = this.UUID;
            model.Points = new XMLNodeXY()
            {
                X = this.Position.X,
                Y = this.Position.Y
            };
        }
        public InputNodeModel<T> model 
        {
            get
            {
                return model;

            }
        }
        public ValueNodeOutputViewModel<T?> Output { get; }
        public InputNodeViewModel()
        {
            Output = new ValueNodeOutputViewModel<T?> {
                Name = "Value",
                Editor = ValueEditor,
                Value = this.WhenAnyValue(vm => vm.ValueEditor.Value)
            };
            this.ValueEditor.ValueChanged.Subscribe(newvalue =>
            {
                model.Value = newvalue;
            });
            this.Outputs.Add(Output);
        }

        
    }
}
