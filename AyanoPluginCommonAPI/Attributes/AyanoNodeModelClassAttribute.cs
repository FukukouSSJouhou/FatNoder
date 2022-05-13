using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyanoPluginCommonAPI.Attributes
{
    public class AyanoNodeModelClassAttribute :Attribute
    {
        public string ModelName { get; set; }
        public string ModelCategory { get; set; }
        public string ModelDescription { get; set; }
        public AyanoNodeModelClassAttribute(string modelName, string modelCategory, string modelDescription):base()
        {
            ModelName = modelName;
            ModelCategory = modelCategory;
            ModelDescription = modelDescription;
        }
    }
}
