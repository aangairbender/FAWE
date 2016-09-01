using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAWE
{
    class ImpetusEffect : Effect
    {
        private float distanceValue;

        public ImpetusEffect(float distanceValue)
        {
            this.distanceValue = distanceValue;
            this.type = EffectType.Impetus;
        }

        public float getDistanceValue()
        {
            return distanceValue;
        }

        public static List<ElementRanges> getSuitRanges()
        {

            List<ElementRanges> result = new List<ElementRanges>();

            ElementRanges ranges = new ElementRanges();
            ranges[(int)ElementType.Air] = new Tuple<float, float>(0.7f, 1);
            result.Add(ranges);

            return result;
        }

        public static float getCarcaseFactor(CarcaseType carcaseType)
        {
            if (carcaseType == CarcaseType.Shield) return 0.8f;
            if (carcaseType == CarcaseType.Dome) return 0f;
            return 1f;
        }

        public static Effect createInstance(Charm charm)
        {
            float distanceValue = 0.3f * charm.getElements().getElement(ElementType.Air) *
                ElementsInfo.getPercentages(charm.getElements())[(int)ElementType.Air];

            Effect effect = new ImpetusEffect(distanceValue);
            return effect;
        }

        override public String getDescription()
        {
            return "Distance: " + distanceValue.ToString();
        }
    }
}
