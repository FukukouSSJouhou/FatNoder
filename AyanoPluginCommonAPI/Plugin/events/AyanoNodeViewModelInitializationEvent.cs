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
    public class AyanoNodeViewModelInitializationEvent
    {
        /// <summary>
        /// event handler
        /// </summary>
        public event EventHandler<AyanoPluginCommonAPI.Plugin.events.evargs.AyanoNodeViewModelInitializationEventArgs> ViewModelRegistered;
        /// <summary>
        /// Object Register
        /// </summary>
        /// <param name="type">type</param>
        public void Register(Type type)
        {
            if(ViewModelRegistered != null)
            {
                var args = new evargs.AyanoNodeViewModelInitializationEventArgs(type);
                ViewModelRegistered(this,args);
            }
        }
    }
}
