using FatNoder.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace FatNoder.Views
{
    /// <summary>
    /// IntegerValueEditorView.xaml の相互作用ロジック
    /// </summary>
    public partial class IntegerValueEditorView : UserControl, IViewFor<HannyouValueEditorViewModel<int>>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty=DependencyProperty.Register(nameof(ViewModel),
            typeof(HannyouValueEditorViewModel<int>),typeof(IntegerValueEditorView),new PropertyMetadata(null));
        public HannyouValueEditorViewModel<int> ViewModel
        {
            get => (HannyouValueEditorViewModel<int>)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set=>ViewModel=(HannyouValueEditorViewModel<int>)value;
        }
        #endregion
        public IntegerValueEditorView()
        {
            InitializeComponent();
            numtextbox.Text = "0";
            this.WhenActivated(d => d(
                this.Bind(ViewModel,vm=>vm.Value,v=>int.Parse(v.numtextbox.Text))
            ));
        }

        private void numtextbox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !new Regex("[0-9]").IsMatch(e.Text);
        }

        private void numtextbox_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {

            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }
    }
}
