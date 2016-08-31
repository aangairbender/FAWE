using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAWE
{
    class HealEffect : Effect
    {
        private int healValue;

        public HealEffect(int healValue)
        {
            this.healValue = healValue;
            this.type = EffectType.Heal;
        }

        public int getHealValue()
        {
            return healValue;
        }


        public static List<ElementRanges> getSuitRanges()
        {

            List<ElementRanges> result = new List<ElementRanges>();

            ElementRanges ranges = new ElementRanges();
            ranges[(int)ElementType.Water] = new Tuple<float, float>(0.9f, 1);
            result.Add(ranges);

            return result;
        }

        public static float getCarcaseFactor(CarcaseType carcaseType)
        {
            if (carcaseType == CarcaseType.Sphere) return 0.7f;
            if (carcaseType == CarcaseType.Shield) return 0.5f;
            return 1f;
        }

        public static Effect createInstance(Charm charm)
        {
            int healValue = 75 * charm.getElements().getElement(ElementType.Water);
            Effect effect = new HealEffect(healValue);
            return effect;
        }

    }
}
