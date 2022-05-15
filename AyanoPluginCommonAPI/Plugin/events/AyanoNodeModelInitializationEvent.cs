using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyanoPluginCommonAPI.Plugin.events
{
    /// <summary>
    /// Initialization event
    /// </summary>
    public class AyanoNodeModelInitializationEvent
    {
        /// <summary>
        /// event handler
        /// </summary>
        public event EventHandler<AyanoPluginCommonAPI.Plugin.events.evargs.AyanoNodeModelInitializationEventArgs> ModelRegistered;
        /// <summary>
        /// Object Register
        /// </summary>
        /// <param name="type">type</param>
        public void Register(Type type)
        {
            if(ModelRegistered != null)
            {
                var args = new evargs.AyanoNodeModelInitializationEventArgs(type);
                ModelRegistered(this,args);
            }
        }
    }
}
