using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAWE
{
    enum EffectType : int { Damage, Heal, Durability, Push};
    class Effect
    {
        private EffectType type;

        public EffectType getType()
        {
            return type;
        }
    }
}
