using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyanoPluginCommonAPI.Attributes
{
    /// <summary>
    /// Initializer Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public sealed class AyanoNodeModelInitializerAttribute:Attribute
    {

    }
}
