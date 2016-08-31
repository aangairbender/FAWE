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
            int elementsCount = Enum.GetNames(typeof(ElementType)).Length;
            List<ElementRanges> result = new List<ElementRanges>();
            switch(effectType)
            {
                case EffectType.Damage:
                    {
                        ElementRanges ranges = new ElementRanges();
                        ranges[(int)ElementType.Fire] = new Tuple<float, float>(0.8f, 1);
                        result.Add(ranges);

                        ranges = new ElementRanges();
                        ranges[(int)ElementType.Earth] = new Tuple<float, float>(0.5f, 0.7f);
                        result.Add(ranges);

                        break;
                    }
                default:
                    {
                        
                        result.Add(new ElementRanges());
                        break;
                    }
            }


            return result;
        }


        public static float getCarcaseFactor(EffectType effectType, CarcaseType carcaseType)
        {
            switch(effectType)
            {
                case EffectType.Damage:
                    {
                        if (carcaseType == CarcaseType.Shield) return 0.8f;
                        if (carcaseType == CarcaseType.Dome) return 0.5f;
                        return 1f;
                    }
                default:
                    {
                        return 1f;
                    }
            }
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
            switch(effectType)
            {
                case EffectType.Damage:
                    {
                        int damageValue = 100 * charm.getElements().getElement(ElementType.Fire); //TODO: fix constant
                        Effect effect = new DamageEffect(damageValue);
                        return effect;
                    }
                default:
                    {
                        Effect effect = new Effect();
                        return effect;
                    }
            }
            
        }

    }
}
