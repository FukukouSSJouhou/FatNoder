﻿using DynamicData;
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
                foreach(NodeOutputViewModel nvo in nvm.Outputs.Items)
                {

                    dynamic dyo = nvo as dynamic;
                    object objkun = dyo as object;
                    Type t = objkun.GetType();
                    if(dyo is ValueNodeOutputViewModel<StatementCls>)
                    {
                        
                    }
                    else
                    {
                        string my_name = nvo.Name;
                        foreach (var c in nvo.Connections.Items)
                        {
                            string target_uuid = c.Input.Parent.UUID.ToString();
                            string target_name = c.Input.Name;

                        }
                    }
                }
                xr.nodes.Add(nobj);
            }
            return xr;
        }
    }
}