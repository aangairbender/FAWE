using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAWE
{
    enum ElementType : int { Fire, Air, Water, Earth };
    class ElementsInfo
    {
        private int[] elements;

        public ElementsInfo(int[] elements)
        {
            this.elements = elements;
        }

        public int[] getArray()
        {
            return elements;
        }

        public int getElement(ElementType element)
        {
            return getElement((int)element);
        }

        public int getElement(int element)
        {
            return elements[element];
        }

        public static float[] getPercentages(ElementsInfo elementsInfo)
        {
            int sum = 0;
            int elementsCount = Enum.GetNames(typeof(ElementType)).Length;
            foreach(ElementType element in Enum.GetValues(typeof(ElementType)))
            {
                sum += elementsInfo.getElement(element);
            }

            float[] result = new float[elementsCount];
            foreach (ElementType element in Enum.GetValues(typeof(ElementType)))
            {
                result[(int)element] = (float)elementsInfo.getElement(element) / sum;
            }

            return result;
        }

    }
}
