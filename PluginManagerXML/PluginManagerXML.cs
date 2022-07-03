using System.Runtime.Serialization;

namespace PluginManagerXML
{
    /// <summary>
    /// Plugin Manager XML
    /// </summary>
    public class PluginManagerXML
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Model DLL
        /// </summary>
        public string ModelDll { get; set; }
        /// <summary>
        /// ViewModel DLL
        /// </summary>
        public string ViewModelDLL { get; set; }
    }
}