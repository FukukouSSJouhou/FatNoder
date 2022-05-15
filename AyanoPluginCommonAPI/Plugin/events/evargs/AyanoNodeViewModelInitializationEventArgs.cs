using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyanoPluginCommonAPI.Plugin.events.evargs
{
    /// <summary>
    /// Event Args
    /// </summary>
    public class AyanoNodeViewModelInitializationEventArgs
    {
        /// <summary>
        /// view model Type
        /// </summary>
        public Type Viewmodeltype { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="viewmodelType">Model Type</param>
        public AyanoNodeViewModelInitializationEventArgs(Type viewmodelType)
        {
            this.Viewmodeltype = viewmodelType;
        }
    }
}
