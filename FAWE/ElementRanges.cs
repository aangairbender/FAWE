using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAWE
{
    class ElementRanges
    {
        private Tuple<float,float>[] ranges;

        public ElementRanges()
        {
            ranges = new Tuple<float,float>[Enum.GetNames(typeof(ElementType)).Length];
            foreach(ElementType elementType in Enum.GetValues(typeof(ElementType)))
            {
                ranges[(int)elementType] = new Tuple<float, float>(2, 2);
            }
        }

        public Tuple<float,float> this[int i]
        {
            get { return ranges[i];  }
            set { ranges[i] = value; }
        }

    }
}
