using FatNoder.Serializer.Node.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyanoVMLibs.ViewModels.Nodes
{
    /// <summary>
    /// NodeViewModelの基礎インターフェース
    /// </summary>
    public interface INodeViewModelBase
    {
        public XML_NodeModel model
        {
            get;
        }
        public void ChangeStates(XML_NodeModel newmodelbs);
    }
}
