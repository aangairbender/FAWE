using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAWE
{
    enum EffectType : int { None, Damage, Heal };
    abstract class Effect
    {
        protected EffectType type;

        public Effect()
        {
            this.type = EffectType.None;

        }
        public EffectType getType()
        {
            return type;
        }

        abstract public String getDescription();

    }
}
