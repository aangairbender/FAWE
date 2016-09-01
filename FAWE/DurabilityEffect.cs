using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAWE
{
    class DurabilityEffect : Effect
    {
        private float durabilityValue;
        private int lifeTimeValue; // in miliseconds

        public DurabilityEffect(float durabilityValue, int lifeTimeValue)
        {
            this.durabilityValue = durabilityValue;
            this.lifeTimeValue = lifeTimeValue;
            this.type = EffectType.Durability;
        }

        public float getDurabilityValue()
        {
            return durabilityValue;
        }

        public int getLifeTimeValue()
        {
            return lifeTimeValue;
        }

        public static List<ElementRanges> getSuitRanges()
        {

            List<ElementRanges> result = new List<ElementRanges>();

            ElementRanges ranges = new ElementRanges();
            ranges[(int)ElementType.Earth] = new Tuple<float, float>(0.8f, 1f);
            result.Add(ranges);


            return result;
        }

        public static float getCarcaseFactor(CarcaseType carcaseType)
        {
            if (carcaseType == CarcaseType.Shield) return 1f;
            return 0f;
        }

        public static Effect createInstance(Charm charm)
        {
            float durabilityValue = 0;
            
            durabilityValue += 150 * charm.getElements().getElement(ElementType.Earth) *
                 ElementsInfo.getPercentages(charm.getElements())[(int)ElementType.Earth];


            durabilityValue += 25 * (ElementsInfo.getPercentages(charm.getElements())[(int)ElementType.Fire] -
                ElementsInfo.getPercentages(charm.getElements())[(int)ElementType.Water]);


            int lifeTimeValue = 4 + charm.getLevel() * charm.getElements().getElement(ElementType.Earth);

            Effect effect = new DurabilityEffect(durabilityValue, lifeTimeValue);
            return effect;
        }

        override public String getDescription()
        {
            return "Durability: " + durabilityValue.ToString() + "; LifeTime: " + lifeTimeValue.ToString();
        }
    }
}
