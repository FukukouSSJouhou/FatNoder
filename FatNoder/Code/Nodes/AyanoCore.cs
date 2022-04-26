using NodeNetworkJH.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.Code.Nodes
{
    /// <summary>
    /// This is a transcompiler.
    /// </summary>
    public class AyanoCore
    {
        private IEnumerable<NodeViewModel> _Nodes;
        public IEnumerable<NodeViewModel> Nodes
        {
            get
            {
                return _Nodes;
            }
            set
            {
                _Nodes = value;
            }
        }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="novms">Nodes</param>
        public AyanoCore(IEnumerable<NodeViewModel> novms)
        {
            _Nodes = novms;
        }
        public string Compile()
        {

        }
    }
}
