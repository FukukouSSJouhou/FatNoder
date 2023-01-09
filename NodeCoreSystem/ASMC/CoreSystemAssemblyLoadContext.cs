using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace NodeCoreSystem.ASMC
{
    public class CoreSystemAssemblyLoadContext:AssemblyLoadContext
    {
        public CoreSystemAssemblyLoadContext() : base(isCollectible: true)
        {

        }
    }
}
