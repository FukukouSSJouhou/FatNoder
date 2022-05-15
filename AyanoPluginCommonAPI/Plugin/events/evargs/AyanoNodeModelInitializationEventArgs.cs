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
    public class AyanoNodeModelInitializationEventArgs
    {
        /// <summary>
        /// model Type
        /// </summary>
        public Type modeltype { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="modelType">Model Type</param>
        public AyanoNodeModelInitializationEventArgs(Type modelType)
        {
            this.modeltype = modelType;
        }
    }
}
