using NodeNetworkJH.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.Serializer.Node.Xml
{
    public class ConvertXMLkun
    {
        public static XmlRootN Serializekun(NetworkViewModel novm)
        {
            XmlRootN xr=new();
            foreach(NodeViewModel nvm in novm.Nodes.Items)
            {

            }
            return xr;
        }
    }
}
