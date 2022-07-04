using PluginManagerXML;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace FatNoder.Plugins
{
    public class PluginLoader
    {
        public static void Load_Plugins()
        {
            string application_dir = System.AppDomain.CurrentDomain.BaseDirectory;
            string plugins_dir = System.IO.Path.Combine(application_dir, "plugins");
            if(Directory.Exists(plugins_dir))
            foreach(DirectoryInfo subdir in new DirectoryInfo(plugins_dir).GetDirectories())
            {
                foreach (FileInfo finfo in subdir.GetFiles("*.pluginmanifest"))
                {
                    using (var streamkun = finfo.OpenRead())
                    {
                        PluginManagerXML.PluginManagerXML jskun = JsonSerializer.Deserialize<PluginManagerXML.PluginManagerXML>(streamkun);
                        Console.WriteLine($"name:{jskun.Name} desc:{jskun.Description} vmdll:{jskun.ViewModelDLL} mdll:{jskun.ModelDll}");

                    }
                }
            }
        }
    }
}
