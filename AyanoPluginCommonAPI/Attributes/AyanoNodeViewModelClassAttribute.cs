using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyanoPluginCommonAPI.Attributes
{
    /// <summary>
    /// ViewModel Class Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class AyanoNodeViewModelClassAttribute :Attribute
    {
        /// <summary>
        /// Model name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// model category
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// model description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="category">category</param>
        /// <param name="description">description</param>
        public AyanoNodeViewModelClassAttribute(string name, string category, string description):base()
        {
            Name = name;
            Category = category;
            Description = description;
        }
        /// <summary>
        /// Initializer Attribute
        /// </summary>
        [AttributeUsage(AttributeTargets.Method)]
        public sealed class InitializerAttribute : Attribute
        {

        }
    }
}
