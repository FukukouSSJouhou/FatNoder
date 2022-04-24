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
            xr.nodes = new XMLRoot_NodesCLskun();
            foreach(NodeViewModel nvm in novm.Nodes.Items)
            {
                XML_NodeViewModel nobj =new XML_NodeViewModel();

                nobj.Name = nvm.Name;
                nobj.UUID = nvm.UUID.ToString();
                nobj.TYPE = nvm.GetType().ToString();
                xr.nodes.Add(nobj);
            }
            return xr;
        }
    }
}
