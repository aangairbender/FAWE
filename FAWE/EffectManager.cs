using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAWE
{
    class EffectManager //TODO: make all constants in another class like EffectBase
    {

        private const float PROBABILITY_FACTOR = 0.9f;

        private static List<ElementRanges> getEffectSuitRanges(EffectType effectType)
        {
            string effectName = Enum.GetName(typeof(EffectType), effectType);
            return (List<ElementRanges>)Type.GetType("FAWE." + effectName + "Effect").GetMethod("getSuitRanges").Invoke(null, null);
        }


        public static float getCarcaseFactor(EffectType effectType, CarcaseType carcaseType)
        {
            if (effectType == EffectType.None) return 0f;
            string effectName = Enum.GetName(typeof(EffectType), effectType);
            return (float)Type.GetType("FAWE." + effectName + "Effect").GetMethod("getCarcaseFactor").Invoke(null, new object[1] { carcaseType });
        }



        public static float getEffectProbability(EffectType effectType, float[] percentages)
        {
            if (effectType == EffectType.None) return 0f;
            List<ElementRanges> percentageRanges = getEffectSuitRanges(effectType);
            float[] probabilities = new float[percentageRanges.Count];
            for (int i = 0; i < percentageRanges.Count; ++i)
            {
                ElementRanges range = percentageRanges[i];
                float probability = 1f;
                foreach (ElementType element in Enum.GetValues(typeof(ElementType)))
                {
                    if (range[(int)element].Item1 > 1) continue;

                    float offset = Math.Max(percentages[(int)element] - range[(int)element].Item2,
                        range[(int)element].Item1 - percentages[(int)element]);
                    if (offset > 0)
                    {
                        probability *= (float)(1.0 - Math.Tanh(offset * 8));
                    }
                    probability *= PROBABILITY_FACTOR;
                }
                probabilities[i] = probability;
            }
            float res = 1;
            for (int i = 0; i < percentageRanges.Count; ++i)
                res *= (1f - probabilities[i]);
            return 1f - res;
        }

        public static float getEffectProbability(EffectType effectType, float[] percentages, CarcaseType carcase)
        {
            float effectProbability = getEffectProbability(effectType, percentages);
            float usingCarcaseProbability = getCarcaseFactor(effectType, carcase);
            return effectProbability * usingCarcaseProbability;
        }

        public static Effect createEffect(EffectType effectType, Charm charm)
        {
            string effectName = Enum.GetName(typeof(EffectType), effectType);
            return (Effect)Type.GetType("FAWE." + effectName + "Effect").GetMethod("createInstance").Invoke(null, new object[1] { charm });          
        }

    }
}
