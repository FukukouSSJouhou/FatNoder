using FatNoder.ViewModels;
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

namespace FatNoder.Views
{
    /// <summary>
    /// StringValueEditorView.xaml の相互作用ロジック
    /// </summary>
    public partial class StringValueEditorView : UserControl,IViewFor<HannyouValueEditorViewModel>
    {
        #region ViewModel
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(HannyouValueEditorViewModel<string>), typeof(StringValueEditorView), new PropertyMetadata(null));
        public HannyouValueEditorViewModel<string> ViewModel
        {
            get => (HannyouValueEditorViewModel<string>)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
        public StringValueEditorView()
        {
            InitializeComponent();
        }
    }
}
