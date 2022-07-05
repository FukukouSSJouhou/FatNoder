using ControlzEx.Standard;
using DynamicData;
using FatNoder.ViewModels;
using FatNoder.ViewModels.Nodes;
using Fluent;
using IconLibrary;
using NodeNetworkJH.ViewModels;
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
            //bind icon
            ExitRibbon.Icon = Iconlib.getIcon_Large("imageres.dll", 244);
            compilePhaseButton.Icon = Iconlib.getIcon_Large("imageres.dll", 280);
            compileandrunPhaseButton.Icon = Iconlib.getIcon_Large("imageres.dll", 281);
            LoadAsRibbon.Icon = Iconlib.getIcon_Large("imageres.dll", 177);
            //ViewModelとの紐づけ(bind)
            this.WhenActivated(d =>
            {
                this.OneWayBind(ViewModel, vm => vm.Network, v => v.network.ViewModel).DisposeWith(d);
                this.OneWayBind(ViewModel, vm => vm.NodeList, v => v.nodeList.ViewModel).DisposeWith(d);
                this.OneWayBind(ViewModel, vm => vm.NetworkBreadcrumbBar, v => v.breadcrumbBar.ViewModel).DisposeWith(d);
                this.OneWayBind(ViewModel, vm => vm.CPreviewViewModel, v => v.CodePreviewViewkun.ViewModel).DisposeWith(d);
                this.BindCommand(ViewModel, vm => vm.AutoLayout, v => v.autoLayoutRibbonButton);


                this.BindCommand(ViewModel, vm => vm.StartAutoLayoutLive, v => v.startAutoLayoutLiveRibbonButton);
                this.WhenAnyObservable(v => v.ViewModel.StartAutoLayoutLive.IsExecuting)
                    .Select((isRunning) => isRunning ? Visibility.Collapsed : Visibility.Visible)
                    .BindTo(this, v => v.startAutoLayoutLiveRibbonButton.Visibility);

                this.BindCommand(ViewModel, vm => vm.StopAutoLayoutLive, v => v.stopAutoLayoutLiveRibbonButton);
                this.WhenAnyObservable(v => v.ViewModel.StartAutoLayoutLive.IsExecuting)
                    .Select((isRunning) => isRunning ? Visibility.Visible : Visibility.Collapsed)
                    .BindTo(this, v => v.stopAutoLayoutLiveRibbonButton.Visibility);
                this.BindCommand(ViewModel, vm => vm.TestPhasekun, v => v.testPhaseButton);
                this.BindCommand(ViewModel, vm => vm.CreateTest, v => v.CreateTestRibbon);
                this.BindCommand(ViewModel, vm => vm.CompilePhasekun, v => v.compilePhaseButton);
                this.BindCommand(ViewModel, vm => vm.CompileandrunPhasekun, v => v.compileandrunPhaseButton);
                this.BindCommand(ViewModel, vm => vm.SaveXMLFileCommand, v => v.SaveAsRibbon);
                this.BindCommand(ViewModel, vm => vm.LoadXMLFileCommand, v => v.LoadAsRibbon);
                this.BindInteraction(ViewModel, vm => vm.SaveXMLFileDialog, interaction =>
                {
                    var dialog = new Microsoft.Win32.SaveFileDialog()
                    {
                        FileName = interaction.Input.FilePath,
                        Filter = "XML File(*.xml)|*.xml|All Files(*)|*.*"
                    };
                    return Observable.Start(() =>
                    {

                        if (dialog.ShowDialog() ?? false)
                        {
                            interaction.SetOutput(new Model.SaveFileRequest()
{
                                FilePath = dialog.FileName,
                                Serializer = interaction.Input.Serializer,
                                RootXML = interaction.Input.RootXML
                            });
                        }
                        else
                        {
                            interaction.SetOutput(new Model.SaveFileRequest()
                            {
                                FilePath = null,
                                Serializer = interaction.Input.Serializer,
                                RootXML = interaction.Input.RootXML
                            });
                        }
                    },
                    RxApp.MainThreadScheduler);
                }).DisposeWith(d);
                this.BindInteraction(ViewModel, vm => vm.LoadXMLFileDialog, interaction =>
                {
                        var dialog = new Microsoft.Win32.OpenFileDialog()
                        {
                            FileName = interaction.Input,
                            Filter = "XML File(*.xml)|*.xml|All Files(*)|*.*"
                        };
                    return Observable.Start(() =>
                    {
                        if (dialog.ShowDialog() ?? false)
                        {
                            interaction.SetOutput(dialog.FileName);
                        }
                        else
                        {
                            interaction.SetOutput(null);
                        }
                    },RxApp.MainThreadScheduler);

                }).DisposeWith(d);
            });
            this.ExitRibbon.Click += ((sender, e) =>
            {
                this.Close();
            });
            
            //viewmodelの設定
            this.ViewModel = new MainViewModel();
        }

        private void RibbonWindow_Closed(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
