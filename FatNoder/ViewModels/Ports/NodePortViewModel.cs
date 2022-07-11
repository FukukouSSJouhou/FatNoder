using NodeNetworkJH.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels.Ports
{
    /// <summary>
    /// Port Type
    /// </summary>
    public enum PortType
    {
        /// <summary>
        /// Statement
        /// </summary>
        Statement,
        /// <summary>
        /// Valuable
        /// </summary>
        Valuable
    }
    /// <summary>
    /// Port VM
    /// </summary>
    public class NodePortViewModel:PortViewModel
    {
        static NodePortViewModel()
        {

        }
        
        #region Port Type
        /// <summary>
        /// Node Port Type
        /// </summary>
        public PortType Node_PortType
        {
            get => _porttype;
            set => this.RaiseAndSetIfChanged(ref _porttype, value);
        }
        private PortType _porttype;
        #endregion
    }
}
