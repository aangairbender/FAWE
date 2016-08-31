using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAWE
{
    class Charm
    {
        protected Charm parent1;
        protected Charm parent2;
        protected float[] effectProbabilities;
        protected int level;
        protected ElementsInfo elements;

        protected Charm()
        {

        }

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
        public float[] getEffectProbabilities()
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
