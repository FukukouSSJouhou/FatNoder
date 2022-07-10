using FatNoder.ViewModels.Nodes.EnzanNodes.Editors;
using FatNoder.ViewModels.Nodes.Sentences.Editors;
using FatNoder.Views.EnzanNodes;
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

namespace FatNoder.Views.Sentences.Editors
{
    /// <summary>
    /// ConditionNodeTypeEditorView.xaml の相互作用ロジック
    /// </summary>
    public partial class ConditionNodeTypeEditorView : UserControl,IViewFor<ConditionNodeTypeEditorViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(ConditionNodeTypeEditorViewModel), typeof(ConditionNodeTypeEditorView), new PropertyMetadata(null));
        public ConditionNodeTypeEditorViewModel ViewModel
        {
            get => (ConditionNodeTypeEditorViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ConditionNodeTypeEditorViewModel)value;
        }
        #endregion
        public ConditionNodeTypeEditorView()
        {
            InitializeComponent();
        }
    }
}
