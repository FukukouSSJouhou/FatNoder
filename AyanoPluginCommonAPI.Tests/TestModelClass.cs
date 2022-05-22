using AyanoPluginCommonAPI.Attributes;
using AyanoPluginCommonAPI.Plugin.events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyanoPluginCommonAPI.Tests
{
    [AyanoNodeModelClass("test1","doutei","tinko")]
    public class TestModelClass
    {
        [AyanoNodeModelClassAttribute.Initializer]
        public void Initializekun(AyanoNodeModelInitializationEvent ev)
        {
            ev.Register(typeof(string));
        }
    }
}
