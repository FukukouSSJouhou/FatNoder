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

namespace NodeCoreSystemVMLibs.ViewModels.Nodes
{
    /// <summary>
    /// 基本機能を備えたNodeViewModelの基幹クラス
    /// </summary>
    public partial class NodeVMBasekun : NodeViewModel
    {
        /// <summary>
        /// Name Changed
        /// </summary>
        public IObservable<string> NameChanged { get; private set; }
        /// <summary>
        /// Position Changed
        /// </summary>
        public IObservable<Point> PositionChanged { get; private set; }
        /// <summary>
        /// UUID!
        /// </summary>
        public IObservable<Guid> UUIDChanged { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public NodeVMBasekun()
        {
            InitNodeVM();
        }
        /// <summary>
        /// Constructor (set UUID)
        /// </summary>
        /// <param name="UUID">UUID</param>
        public NodeVMBasekun(Guid UUID) : base(UUID)
        {
            InitNodeVM();
        }
        static NodeVMBasekun()
        {

            Splat.Locator.CurrentMutable.Register(() => new NodeView(), typeof(IViewFor<NodeVMBasekun>));
        }
    }
}
