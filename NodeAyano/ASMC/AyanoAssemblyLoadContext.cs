using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyano.ASMC
{
    public class AyanoAssemblyLoadContext:AssemblyLoadContext
    {
        public AyanoAssemblyLoadContext() : base(isCollectible: true)
        {

        }
    }
}
