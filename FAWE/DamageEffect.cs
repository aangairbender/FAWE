using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAWE
{
    class DamageEffect : Effect 
    {
        private float damageValue;

        public DamageEffect(float damageValue)
        {
            this.damageValue = damageValue;
            this.type = EffectType.Damage;
        }

        public float getDamageValue()
        {
            return damageValue;
        }

        public static List<ElementRanges> getSuitRanges()
        {

            List<ElementRanges> result = new List<ElementRanges>();

            ElementRanges ranges = new ElementRanges();
            ranges[(int)ElementType.Fire] = new Tuple<float, float>(0.8f, 1);
            result.Add(ranges);

            ranges = new ElementRanges();
            ranges[(int)ElementType.Earth] = new Tuple<float, float>(0.5f, 0.7f);
            result.Add(ranges);

            return result;
        }

        public static float getCarcaseFactor(CarcaseType carcaseType)
        {
            if (carcaseType == CarcaseType.Shield) return 0.8f;
            if (carcaseType == CarcaseType.Dome) return 0.5f;
            return 1f;
        }

        public static Effect createInstance(Charm charm)
        {
            float damageValue = 100 * charm.getElements().getElement(ElementType.Fire) *
                ElementsInfo.getPercentages(charm.getElements())[(int)ElementType.Fire];

            damageValue += 75 * charm.getElements().getElement(ElementType.Earth) *
                ElementsInfo.getPercentages(charm.getElements())[(int)ElementType.Earth];

            Effect effect = new DamageEffect(damageValue);
            return effect;
        }

        override public String getDescription()
        {
            return "Immediate damage: " + damageValue.ToString();
        }

    }
}
