using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAWE
{
    class AirCharm : Charm
    {
        private static AirCharm singleton;

        private AirCharm()
        {
            parent1 = null;
            parent2 = null;
            int[] elemAmounts = new int[Enum.GetNames(typeof(ElementType)).Length];
            elemAmounts[(int)ElementType.Air] = 1;
            elements = new ElementsInfo(elemAmounts);
            level = 1;
            effectProbabilities = new float[Enum.GetNames(typeof(EffectType)).Length];
            float[] percentages = ElementsInfo.getPercentages(elements);
            foreach (EffectType effect in Enum.GetValues(typeof(EffectType)))
            {
                effectProbabilities[(int)effect] = EffectManager.getEffectProbability(effect, percentages);
            }
        }

        public static Charm getInstance()
        {
            if (singleton == null)
                singleton = new AirCharm();
            return singleton;
        }

    }
}
