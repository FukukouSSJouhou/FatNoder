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
    public class ConvertXMLkun
    {
        public static XmlRootN Serializekun(NetworkViewModel novm,ref List<Type> knowTypeList)
        {
            XmlRootN xr=new();
            xr.nodes = new XMLRoot_NodesCLskun();
            foreach (NodeViewModel nvm in novm.Nodes.Items)
            {
                XML_NodeViewModel nobj =new XML_NodeViewModel();

                nobj.Name = nvm.Name;
                nobj.UUID = nvm.UUID.ToString();
                nobj.TYPE = nvm.GetType().ToString();
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

                    dynamic dyo = nvo as dynamic;
                    object objkun = dyo as object;
                    Type t = objkun.GetType();
                    if(dyo is ValueNodeOutputViewModel<StatementCls>)
                    {
                        
                    }
                    else
                    {
                        XMLNodeOutput o=new XMLNodeOutput();
                        o.Name = nvo.Name;
                        o.connections=new XMLNodeOutputConnectS();
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
