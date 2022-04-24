using FatNoder.Serializer.Node.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels.Xml
{
    public interface INVModelXML
    {
        XmlNodeDatas GetXMLNodeDT();
        void SetXMLNodeDT(XmlNodeDatas xmldt);
    }
}
