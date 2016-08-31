using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAWE
{
    class Charm
    {
        private Charm parent1;
        private Charm parent2;
        private float[] effectProbabilities;
        private int level;
        private ElementsInfo elements;

        public Charm(Charm parent1, Charm parent2, float[] effectProbabilities, int level, ElementsInfo elements)
        {
            this.parent1 = parent1;
            this.parent2 = parent2;
            this.effectProbabilities = effectProbabilities;
            this.level = level;
            this.elements = elements;
        }

        public Charm getFirstParent()
        {
            return parent1;
        }
        public Charm getSecondParent()
        {
            return parent2;
        }
        public float[] getEffectProbabibilities()
        {
            return effectProbabilities;
        }
        public int getLevel()
        {
            return level;
        }
        public ElementsInfo getElements()
        {
            return elements;
        }



    }
}
