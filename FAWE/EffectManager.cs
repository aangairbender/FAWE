using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAWE
{
    class EffectManager //TODO: make all constants in another class like EffectBase
    {

        private const float PROBABILITY_FACTOR_MIN = 0.5f;
        private const float PROBABILITY_FACTOR_MAX = 0.9f;

        private static Tuple<float, float>[] getEffectSuitRanges(EffectType effectType)
        {
            Tuple<float, float>[] ranges = new Tuple<float, float>[Enum.GetNames(typeof(ElementType)).Length];
            
            switch(effectType)
            {
                case EffectType.Damage:
                    {
                        ranges[(int)ElementType.Air] = new Tuple<float, float>(2, 2);//means 100% probability
                        ranges[(int)ElementType.Earth] = new Tuple<float, float>(2, 2);
                        ranges[(int)ElementType.Fire] = new Tuple<float, float>(0.8f, 1);
                        ranges[(int)ElementType.Water] = new Tuple<float, float>(2, 2);
                        break;
                    }
                default:
                    {
                        ranges[(int)ElementType.Air] = new Tuple<float, float>(-2, -2);//means 0% probability
                        ranges[(int)ElementType.Earth] = new Tuple<float, float>(-2, -2);
                        ranges[(int)ElementType.Fire] = new Tuple<float, float>(-2, -2);
                        ranges[(int)ElementType.Water] = new Tuple<float, float>(-2, -2);
                        break;
                    }
            }


            return ranges;
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
            Tuple<float, float>[] percentageRanges = getEffectSuitRanges(effectType);
            float probability = 1f;
            foreach(ElementType element in Enum.GetValues(typeof(ElementType)))
            {
                if (percentageRanges[(int)element].Item1 > 1) continue;

                if (percentageRanges[(int)element].Item1 > percentages[(int)element] ||
                    percentageRanges[(int)element].Item2 < percentages[(int)element])
                {
                    probability = 0f;
                    break;
                }
                float middle = (percentageRanges[(int)element].Item1 + percentageRanges[(int)element].Item2) / 2;
                float halfRangeLength = (percentageRanges[(int)element].Item2 - percentageRanges[(int)element].Item1);
                float curDist = Math.Abs(percentages[(int)element] - middle);
                probability *= PROBABILITY_FACTOR_MIN + (halfRangeLength - curDist) / halfRangeLength * (PROBABILITY_FACTOR_MAX - PROBABILITY_FACTOR_MIN);
            }
            return probability;
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
