using FatNoder.Serializer.Node.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels.Nodes
{
    public interface INodeViewModelBase
    {
        public XML_NodeModel model
        {
            get;
        }
        public void INodeViewModelBase(XML_NodeModel newmodelbs);
    }
}
