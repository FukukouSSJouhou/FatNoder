using NodeNetworkJH.Toolkit.ValueNode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.ViewModels.Conv
{
    public class NodeTextConverter
    {
        public static void conv(dynamic obj)
        {
            if (obj is ValueNodeInputViewModel<string>)
            {
                string valuekun = obj.Value as string;
                Console.WriteLine($"\t\tValue:{valuekun}");
            }
        }
    }
}
