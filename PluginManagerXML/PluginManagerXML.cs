using System.Runtime.Serialization;

namespace PluginManagerXML
{
    /// <summary>
    /// Plugin Manager XML
    /// </summary>
    [DataContract(Name = "plugin")]
    public class PluginManagerXML
    {
        /// <summary>
        /// Name
        /// </summary>
        [DataMember(Name = "Name")]
        public string Name { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        [DataMember(Name = "Description")]
        public string Description { get; set; }
        /// <summary>
        /// Model DLL
        /// </summary>
        [DataMember(Name = "ModelDLL")]
        public string ModelDll { get; set; }
        /// <summary>
        /// ViewModel DLL
        /// </summary>
        [DataMember(Name = "ViewModelDLL")]
        public string ViewModelDLL { get; set; }
        /// <summary>
        /// Model Class
        /// </summary>
        [DataMember(Name = "ModelClass")]
        public string ModelClass { get; set; }
        /// <summary>
        /// ViewModel Class
        /// </summary>
        [DataMember(Name = "ViewModelClass")]
        public string ViewModelClass { get; set; }
    }
}