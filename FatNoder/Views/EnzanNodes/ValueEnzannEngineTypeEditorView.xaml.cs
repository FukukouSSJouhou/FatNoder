using FatNoder.ViewModels;
using FatNoder.ViewModels.Nodes.EnzanNodes.Editors;
using NodeAyano.Model.Nodes.ValueEnzann;
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

namespace FatNoder.Views.EnzanNodes
{
    /// <summary>
    /// ValueEnzannEngineTypeEditorView.xaml の相互作用ロジック
    /// </summary>
    public partial class ValueEnzannEngineTypeEditorView : UserControl,IViewFor<ValueEnzannEngineTypeEditorViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(ValueEnzannEngineTypeEditorViewModel), typeof(ValueEnzannEngineTypeEditorView), new PropertyMetadata(null));
        public ValueEnzannEngineTypeEditorViewModel ViewModel
        {
            get => (ValueEnzannEngineTypeEditorViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (ValueEnzannEngineTypeEditorViewModel)value;
        }
        #endregion
        public ValueEnzannEngineTypeEditorView()
        {
            InitializeComponent();

            this.WhenActivated(d => {
                d(
                    this.Bind(ViewModel, vm => vm.Value, v => v.valuetypecombo.SelectedValue)
                    );
                d(
                    this.Bind(ViewModel, vm => vm.selectedIndexView, v => v.valuetypecombo.SelectedIndex));
                valuetypecombo.ItemsSource = ViewModel.ValueEnzannEngineEnum;
            }
            ) ;
        }
    }
}
