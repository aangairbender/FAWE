using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAWE
{
    class Spell
    {
        private List<Effect> effects;
        private CarcaseType carcase;
        private Charm charm;

        
        public Spell(List<Effect> effects, CarcaseType carcase, Charm charm)
        {
            this.effects = effects;
            this.carcase = carcase;
            this.charm = charm;
        }

        public List<Effect> getEffects()
        {
            return effects;
        }

        public CarcaseType getCarcase()
        {
            return carcase;
        }

        public Charm getCharm()
        {
            return charm;
        }

    }
}
