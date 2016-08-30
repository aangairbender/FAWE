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
        private List<Effect> availableEffects;
        private int level;
        private ElementsInfo elements;

        public Charm getFirstParent()
        {
            return parent1;
        }
        public Charm getSecondParent()
        {
            return parent2;
        }
        public List<Effect> getAvailableEffects()
        {
            return availableEffects;
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
