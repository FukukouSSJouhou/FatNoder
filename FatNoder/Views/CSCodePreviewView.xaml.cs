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
    /// CSCodePreviewView.xaml の相互作用ロジック
    /// </summary>
    public partial class CSCodePreviewView : IViewFor<CSCodePreviewViewModel>
    {
        #region VM
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(CSCodePreviewViewModel), typeof(CSCodePreviewView), new PropertyMetadata(null));
        public CSCodePreviewViewModel ViewModel
        {

            get=>(CSCodePreviewViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }
        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (CSCodePreviewViewModel)value;
        }
        #endregion
        public CSCodePreviewView()
        {
            InitializeComponent();
        }
    }
}
