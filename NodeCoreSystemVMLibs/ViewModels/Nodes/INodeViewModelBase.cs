using FatNoder.Serializer.Node.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeCoreSystemVMLibs.ViewModels.Nodes
{
    /// <summary>
    /// NodeViewModelの基礎インターフェース
    /// </summary>
    public interface INodeViewModelBase
    {
        /// <summary>
        /// Model(MVVM)
        /// </summary>
        public XML_NodeModel model
        {
            get;
        }
        /// <summary>
        /// Change Model Data(Not Direct)
        /// </summary>
        /// <param name="newmodelbs">New Model Data!</param>
        public void ChangeStates(XML_NodeModel newmodelbs);
    }
}
