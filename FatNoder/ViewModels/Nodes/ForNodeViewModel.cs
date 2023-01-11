using NodeAyano.Model.Nodes;
using NodeAyanoVMLibs.ViewModels.Nodes;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AyanoNodeVM;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeAyano.HensuuV;
using FatNoder.Model.Transc;
using FatNoder.Serializer.Node.Xml;
using ControlzEx.Standard;
using NodeNetworkJH.ViewModels;

namespace FatNoder.ViewModels.Nodes
{
    public partial class ForNodeViewModel:StatementNodeViewModelBase,INodeViewModelBase
    {
        private ValueNodeInputViewModel<HensuuUkewatashi?> Condition { get; }
        public ValueListNodeInputViewModel<StatementCls> DefineFor { get; }
        public ValueListNodeInputViewModel<StatementCls> OutFor { get; }
        static ForNodeViewModel()
        {
            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<ForNodeViewModel>));
        }
        [ModelAyano]
        private ForNodeModel _model = new ForNodeModel();
        public ForNodeViewModel(Guid uuid) : base(uuid)
        {
            InitAyanoVMB();
            Condition = new ValueNodeInputViewModel<HensuuUkewatashi?>
            {
                Name = "Condition",
                Label = Properties.Resources.ForNodeViewModel_ConditionLabel,
                MaxConnections = 1
            };
            DefineFor = new ValueListNodeInputViewModel<StatementCls>
            {
                Name = "Define",
                Label = Properties.Resources.ForNodeViewModel_DefineLabel,
                MaxConnections = 1,
                PortPosition = PortPosition.Right
            };
            OutFor = new ValueListNodeInputViewModel<StatementCls>
            {
                Name = "Then",
                Label = Properties.Resources.ForNodeViewModel_ThenLabel,
                MaxConnections = 1,
                PortPosition = PortPosition.Right
            };
        }
        /// <inheritdoc/>
        public void ChangeStates(XML_NodeModel newmodelbs)
        {

            Name = Properties.Resources.ForNodeViewModel_ForNodeLabel;
            Position = new System.Windows.Point
            {
                X = newmodelbs.Points.X,
                Y = newmodelbs.Points.Y
            };
            _model.Value = ((ForNodeModel)newmodelbs).Value;
        }
    }
}
