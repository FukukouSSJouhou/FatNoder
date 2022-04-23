using DynamicData;
using FatNoder.ViewModels;
using FatNoder.ViewModels.Nodes;
using Fluent;
using NodeNetwork.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
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

namespace FatNoder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow, IViewFor<MainViewModel>
    {
        #region ViewModel

        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(nameof(ViewModel),
            typeof(MainViewModel), typeof(MainWindow), new PropertyMetadata(null));

        public MainViewModel ViewModel
        {
            get => (MainViewModel)GetValue(ViewModelProperty);
            set => SetValue(ViewModelProperty, value);
        }

        object IViewFor.ViewModel
        {
            get => ViewModel;
            set => ViewModel = (MainViewModel)value;
        }
        #endregion  
        public MainWindow()
        {
            InitializeComponent();

            this.WhenActivated(d =>
            {
                this.OneWayBind(ViewModel, vm => vm.Network, v => v.network.ViewModel).DisposeWith(d);
                this.OneWayBind(ViewModel, vm => vm.NodeList, v => v.nodeList.ViewModel).DisposeWith(d);
                this.OneWayBind(ViewModel, vm => vm.NetworkBreadcrumbBar, v => v.breadcrumbBar.ViewModel).DisposeWith(d);

                this.BindCommand(ViewModel, vm => vm.AutoLayout, v => v.autoLayoutButton);


                this.BindCommand(ViewModel, vm => vm.StartAutoLayoutLive, v => v.startAutoLayoutLiveButton);
                this.WhenAnyObservable(v => v.ViewModel.StartAutoLayoutLive.IsExecuting)
                    .Select((isRunning) => isRunning ? Visibility.Collapsed : Visibility.Visible)
                    .BindTo(this, v => v.startAutoLayoutLiveButton.Visibility);

                this.BindCommand(ViewModel, vm => vm.StopAutoLayoutLive, v => v.stopAutoLayoutLiveButton);
                this.WhenAnyObservable(v => v.ViewModel.StartAutoLayoutLive.IsExecuting)
                    .Select((isRunning) => isRunning ? Visibility.Visible : Visibility.Collapsed)
                    .BindTo(this, v => v.stopAutoLayoutLiveButton.Visibility);
                this.BindCommand(ViewModel, vm => vm.TestPhasekun, v => v.testPhaseButton);
            });

            this.ViewModel = new MainViewModel();
        }
    }
}
