using FatNoder.ViewModels.Ports;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FatNoder.Views.Ports
{
    /// <summary>
    /// NodePortView.xaml の相互作用ロジック
    /// </summary>
    public partial class NodePortView : UserControl,IViewFor<NodePortViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(NodePortViewModel), typeof(NodePortView), new PropertyMetadata(null));
        public NodePortViewModel ViewModel
        {
            get => (NodePortViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (NodePortViewModel)value;
        }
        #endregion
        #region Template Resource Keys
        public const string StatementPortTemplateKey = "StatementPortTemplateKey";
        public const string ValuablePortTemplateKey = "ValuablePortTemplateKey";
        #endregion
        public NodePortView()
        {
            InitializeComponent();
        }
        public ControlTemplate GetTemplateFromPortType(PortType porttype)
        {
            switch (porttype)
            {
                case PortType.Statement: return (ControlTemplate)Resources[StatementPortTemplateKey];
                case PortType.Valuable:  return (ControlTemplate)Resources[ValuablePortTemplateKey];
                default:throw new Exception("Unknown Port Type");
            }
        }
    }
}
