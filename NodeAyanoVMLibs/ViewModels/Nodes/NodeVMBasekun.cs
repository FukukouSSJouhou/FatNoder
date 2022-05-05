using FatNoder.Serializer.Node.Xml;
using NodeNetworkJH.ViewModels;
using NodeNetworkJH.Views;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NodeAyanoVMLibs.ViewModels.Nodes
{
    /// <summary>
    /// 基本機能を備えたNodeViewModelの基幹クラス
    /// </summary>
    public class NodeVMBasekun : NodeViewModel
    {
        /// <summary>
        /// Name Changed
        /// </summary>
        public IObservable<string> NameChanged { get; }
        /// <summary>
        /// Position Changed
        /// </summary>
        public IObservable<Point> PositionChanged { get; }
        /// <summary>
        /// UUID!
        /// </summary>
        public IObservable<Guid> UUIDChanged { get; }

        /// <summary>
        /// Constructor
        /// </summary>
        public NodeVMBasekun()
        {

            NameChanged = this.WhenAnyValue(vm => vm.Name);
            PositionChanged = this.WhenAnyValue(vm => vm.Position);
            UUIDChanged = this.WhenAnyValue(vm => vm.UUID);
        }
        /// <summary>
        /// Constructor (set UUID)
        /// </summary>
        /// <param name="UUID">UUID</param>
        public NodeVMBasekun(Guid UUID) : base(UUID)
        {

            NameChanged = this.WhenAnyValue(vm => vm.Name);
            PositionChanged = this.WhenAnyValue(vm => vm.Position);
            UUIDChanged = this.WhenAnyValue(vm => vm.UUID);
        }
        static NodeVMBasekun()
        {

            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<NodeVMBasekun>));
        }
    }
}
