using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NodeAyano.HensuuV
{
    /// <summary>
    /// Ukewatashii
    /// </summary>
    public class HensuuUkewatashi
    {
        /// <summary>
        /// Type
        /// </summary>
        public Type type { get; set; }
        public HensuuUkewatashi(Type T)
        {
            type = T;
        }
        public HensuuUkewatashi()
        {
            type = typeof(object);
        }

    }
}
