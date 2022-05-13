using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyanoPluginCommonAPI.Attributes
{
    /// <summary>
    /// Model Class Attribute
    /// </summary>
    public class AyanoNodeModelClassAttribute :Attribute
    {
        /// <summary>
        /// Model name
        /// </summary>
        public string ModelName { get; set; }
        /// <summary>
        /// model category
        /// </summary>
        public string ModelCategory { get; set; }
        /// <summary>
        /// model description
        /// </summary>
        public string ModelDescription { get; set; }
        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="modelName">name</param>
        /// <param name="modelCategory">category</param>
        /// <param name="modelDescription">description</param>
        public AyanoNodeModelClassAttribute(string modelName, string modelCategory, string modelDescription):base()
        {
            ModelName = modelName;
            ModelCategory = modelCategory;
            ModelDescription = modelDescription;
        }
    }
}
