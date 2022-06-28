﻿using NodeAyanoVMLibs.ViewModels.Nodes;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AyanoNodeVM;
using NodeAyano.Model.Nodes;
using FatNoder.Serializer.Node.Xml;
using NodeNetworkJH.Toolkit.ValueNode;
using DynamicData;

namespace FatNoder.ViewModels.Nodes
{
    public partial class GetValueNodeViewModel<T> : NodeVMBasekun, INodeViewModelBase
    {
        static GetValueNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<GetValueNodeViewModel<T>>));
        }
        [ModelAyano]
        private GetValueNodeModel<T> _model = new GetValueNodeModel<T>();
        /// <summary>
        /// Output Value?
        /// </summary>
        public ValueNodeOutputViewModel<T?> Output { get; }
        /// <summary>
        /// Name Input
        /// </summary>
        public ValueNodeInputViewModel<string?> NameInput { get; }
        ///<inheritdoc/>
        public GetValueNodeViewModel(Guid uuid) : base(uuid)
        {
            InitAyanoVMB();

            _model.InputOnly = true;
            Output = new ValueNodeOutputViewModel<T?>
            {
                Name = "Value"
            };
            NameInput = new ValueNodeInputViewModel<string?>
            {
                Name = "Name",
                MaxConnections = 1
            };
            NameInput.ValueChanged.Subscribe(newvalue =>
            {
                _model.ValueName = newvalue;
            });
            NameInput.Editor = new HannyouValueEditorViewModel<string>();
            NameInput.Port.IsVisible = false;
            InitConstructor();
        }
        ///<inheritdoc/>
        public GetValueNodeViewModel() : base()
        {
            InitAyanoVMB();

            _model.InputOnly = true;
            Output = new ValueNodeOutputViewModel<T?>
            {
                Name = "Value"
            };
            NameInput = new ValueNodeInputViewModel<string?>
            {
                Name = "Name",
                MaxConnections = 1
            };
            NameInput.ValueChanged.Subscribe(newvalue =>
            {
                _model.ValueName = newvalue;
            });
            NameInput.Editor = new HannyouValueEditorViewModel<string>();
            NameInput.Port.IsVisible = false;
            InitConstructor();
        }
        ///<inheritdoc/>
        public void ChangeStates(XML_NodeModel newmodelbs)
        {

            Name = newmodelbs.Name;
            Position = new System.Windows.Point
            {
                X = newmodelbs.Points.X,
                Y = newmodelbs.Points.Y
            };
            _model.ValueName = ((SetValueNodeModel<T>)newmodelbs).ValueName;
            ((HannyouValueEditorViewModel<string>)NameInput.Editor).Value = _model.ValueName;
        }

        private void InitConstructor()
        {

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
            Inputs.Add(NameInput);
            Outputs.Add(Output);
        }
    }
}