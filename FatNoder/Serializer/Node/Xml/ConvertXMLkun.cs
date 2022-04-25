using DynamicData;
using FatNoder.Model.Transc;
using FatNoder.ViewModels.Xml;
using NodeNetworkJH.Toolkit.ValueNode;
using NodeNetworkJH.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.Serializer.Node.Xml
{
    /// <summary>
    /// XMLに変換したりする機能があるclass
    /// </summary>
    public class ConvertXMLkun
    {
        /// <summary>
        /// NetworkViewModelをXMLでSerialize可能なオブジェクトにする
        /// </summary>
        /// <param name="novm">NetworkViewModelの中身</param>
        /// <param name="knowTypeList">シリアライザーが使う型リスト(参照型)</param>
        /// <returns>Serialize可能なオブジェクト</returns>
        public static XmlRootN Serializekun(NetworkViewModel novm,ref List<Type> knowTypeList)
        {
            XmlRootN xr=new();
            xr.nodes = new XMLRoot_NodesCLskun();
            foreach (NodeViewModel nvm in novm.Nodes.Items)
            {
                XML_NodeViewModel nobj =new XML_NodeViewModel();
                nobj.Points = new XMLNodeXY();
                nobj.Name = nvm.Name;
                nobj.UUID = nvm.UUID.ToString();
                nobj.TYPE = nvm.GetType().ToString();
                nobj.Points.X = nvm.Position.X.ToString();
                nobj.Points.Y = nvm.Position.Y.ToString();
                nobj.InputStates = new XMLNodeInputStatement_VMLS();
                dynamic dynvn = nvm as dynamic;
                if (dynvn is INVModelXML)
                {
                    INVModelXML dtkun=dynvn as INVModelXML;
                    XmlNodeDatas  dt= dtkun.GetXMLNodeDT();
                    nobj.DTTYPE = dt.GetType().ToString();
                    if (!knowTypeList.Contains(dt.GetType()))
                    {
                        knowTypeList.Add(dt.GetType());
                    }
                    nobj.Datas = dt;

                    Console.Write("");
                }
                foreach (NodeInputViewModel nvi in nvm.Inputs.Items)
                {

                    dynamic dyi = nvi;
                    if (dyi is ValueListNodeInputViewModel<StatementCls>)
                    {
                        var statementkun = new XMLNodeInputStatement();
                        statementkun.States = new XMLNodeInputStatementLS();
                        statementkun.Name = dyi.Name;
                        IObservableList<StatementCls> valueskun;
                        
                        valueskun = dyi.Values as IObservableList<StatementCls>;

                        foreach (StatementCls s in valueskun.Items)
                        {
                            statementkun.States.Add(s.UUID.ToString());
                        }
                        nobj.InputStates.Add(statementkun);
                    }
                }
                nobj.Outputs = new XMLNodeOutputS();
                foreach (NodeOutputViewModel nvo in nvm.Outputs.Items)
                {

                    dynamic dyo = nvo;
                    if(dyo is ValueNodeOutputViewModel<StatementCls>)
                    {
                        
                    }
                    else
                    {
                        XMLNodeOutput o = new XMLNodeOutput
                        {
                            Name = nvo.Name,
                            connections = new XMLNodeOutputConnectS()
                        };
                        foreach (var c in nvo.Connections.Items)
                        {
                            XMLNodeOutputConnect cn=new XMLNodeOutputConnect();
                            cn.Target = c.Input.Parent.UUID.ToString();
                            cn.Name = c.Input.Name;
                            o.connections.Add(cn);
                        }
                        nobj.Outputs.Add(o);
                    }
                }
                xr.nodes.Add(nobj);
            }
            return xr;
        }
    }
}
