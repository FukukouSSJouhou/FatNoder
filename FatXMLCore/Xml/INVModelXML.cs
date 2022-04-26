using FatNoder.Serializer.Node.Xml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels.Xml
{
    /// <summary>
    /// 保存用XMLノードを使うインターフェース
    /// </summary>
    public interface INVModelXML
    {
        /// <summary>
        /// XMLノードを取得
        /// </summary>
        /// <returns>XML Node</returns>
        XmlNodeDatas GetXMLNodeDT();
        /// <summary>
        /// xmlノードからオブジェクトに値を戻す
        /// </summary>
        /// <param name="xmldt">XML Node</param>
        void SetXMLNodeDT(XmlNodeDatas xmldt);
    }
}
