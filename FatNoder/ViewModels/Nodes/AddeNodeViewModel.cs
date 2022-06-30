﻿using NodeAyano.Model.Nodes;
using NodeAyanoVMLibs.ViewModels.Nodes;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AyanoNodeVM;
using DynamicData;
using NodeAyano.HensuuV;
using NodeNetworkJH.Toolkit.ValueNode;
using FatNoder.Serializer.Node.Xml;

namespace FatNoder.ViewModels.Nodes
{
    public partial class AddeNodeViewModel: NodeVMBasekun, INodeViewModelBase
    {
        static AddeNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(()=>new NodeView(),typeof(IViewFor<AddeNodeViewModel>));
        }
        [ModelAyano]
        private AddNodeModel _model = new AddNodeModel();

        /// <summary>
        /// Output Value?
        /// </summary>
        public ValueNodeOutputViewModel<HensuuUkewatashi?> Output { get; }
        private HensuuUkewatashi hkun = new HensuuUkewatashi();
        public ValueNodeInputViewModel<HensuuUkewatashi?> Input1 { get; }

        public ValueNodeInputViewModel<HensuuUkewatashi?> Input2 { get; }

        public AddeNodeViewModel(Guid uuid) : base(uuid)
        {

            InitAyanoVMB();
            _model.InputOnly = true;
            Output = new ValueNodeOutputViewModel<HensuuUkewatashi?>
            {
                Name = "Value",
                Value = this.WhenAnyValue(vm => vm.hkun)
            };
            Input1 = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name="Input1",
                MaxConnections=1
            };
            Input2 = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "Input2",
                MaxConnections = 1
            };
            InitConstructor();
        }
        public AddeNodeViewModel():base()
        {

            InitAyanoVMB();
            _model.InputOnly = true;
            Output = new ValueNodeOutputViewModel<HensuuUkewatashi?>
            {
                Name = "Value",
                Value = this.WhenAnyValue(vm => vm.hkun)
            };
            Input1 = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "Input1",
                MaxConnections = 1
            };
            Input2 = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "Input2",
                MaxConnections = 1
            };
            InitConstructor();
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

            _model.Inputs = new XMLNodeInputS
            {
                new XMLNodeInput()
                {
                    Name = Input1.Name,
                    connections=new XMLNodeInputConnectS
                    {

                    }
                },
                new XMLNodeInput()
                {
                    Name = Input2.Name,
                    connections=new XMLNodeInputConnectS
                    {

                    }
                }
            };
            this.Outputs.Add(Output);

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
        }

    }
}
