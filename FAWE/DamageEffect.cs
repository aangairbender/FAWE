using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAWE
{
    class DamageEffect : Effect
    {
        private int damageValue;

        public DamageEffect(int damageValue)
        {
            this.damageValue = damageValue;
            this.type = EffectType.Damage;
        }

        public int getDamageValue()
        {
            return damageValue;
        }

    }
}
