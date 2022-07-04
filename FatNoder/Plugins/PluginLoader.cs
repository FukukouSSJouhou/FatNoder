using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FatNoder.Plugins
{
    public class PluginLoader
    {
        public void Load_Plugins()
        {
            string application_dir = System.AppDomain.CurrentDomain.BaseDirectory;
            string plugins_dir = System.IO.Path.Combine(application_dir, "plugins");
            foreach(DirectoryInfo subdir in new DirectoryInfo(plugins_dir).GetDirectories())
            {

            }
        }
    }
}
