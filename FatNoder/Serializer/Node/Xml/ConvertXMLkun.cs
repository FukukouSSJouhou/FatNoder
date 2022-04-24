using DynamicData;
using FatNoder.Model.Transc;
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
                nobj.InputStates = new XMLNodeInputStatement_VMLS();
                foreach (NodeInputViewModel nvi in nvm.Inputs.Items)
                {

                    dynamic dyi = nvi as dynamic;
                    object objkun = dyi as object;
                    Type t = objkun.GetType();
                    if (dyi is ValueListNodeInputViewModel<StatementCls>)
                    {
                        var statementkun = new XMLNodeInputStatement();
                        statementkun.States = new XMLNodeInputStatementLS();
                        IObservableList<StatementCls> valueskun;
                        
                        valueskun = dyi.Values as IObservableList<StatementCls>;

                        foreach (StatementCls s in valueskun.Items)
                        {
                            statementkun.States.Add(s.UUID.ToString());
                        }
                        nobj.InputStates.Add(statementkun);
                    }
                }
                xr.nodes.Add(nobj);
            }
            return xr;
        }
    }
}
