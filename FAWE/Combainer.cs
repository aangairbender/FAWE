using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FAWE
{
    enum CarcaseType : int { Sphere, Shield, Dome };
    class Combainer
    {
        private static Random rand = new Random();
        public static Charm combineCharms(Charm charmA, Charm charmB)
        {
            int newLevel = Math.Max(charmA.getLevel(), charmB.getLevel()) + 1;

            int[] newElements = new int[Enum.GetNames(typeof(ElementType)).Length];
            ElementsInfo elementsA = charmA.getElements();
            float[] percantagesA = ElementsInfo.getPercentages(elementsA);
            ElementsInfo elementsB = charmB.getElements();
            float[] percantagesB = ElementsInfo.getPercentages(elementsB);
            float[] averagePercantages = new float[Enum.GetNames(typeof(ElementType)).Length];
            foreach(ElementType element in Enum.GetValues(typeof(ElementType)))
            {
                newElements[(int)element] = elementsA.getElement(element) + elementsB.getElement(element);
                averagePercantages[(int)element] = (percantagesA[(int)element] + percantagesB[(int)element]) / 2;
            }

            float[] effectProbabilities = new float[Enum.GetNames(typeof(EffectType)).Length];
            float[] effectProbabilitiesA = charmA.getEffectProbabibilities();
            float[] effectProbabilitiesB = charmB.getEffectProbabibilities();
            foreach(EffectType effect in Enum.GetValues(typeof(EffectType)))
            {
                float parentFactor = 0.5f; //effects can only disappear
                parentFactor += 0.25f * effectProbabilitiesA[(int)effect];
                parentFactor += 0.25f * effectProbabilitiesB[(int)effect];

                float probability = EffectManager.getEffectProbability(effect, averagePercantages);
                probability *= parentFactor;

                effectProbabilities[(int)effect] = probability;

            }

            return new Charm(charmA, charmB, effectProbabilities, newLevel, new ElementsInfo(newElements));
        }

        public static Spell createSpell(Charm charm, CarcaseType carcase)
        {
            List<Effect> effects = new List<Effect>();
            float[] effectProbabilities = charm.getEffectProbabibilities();
            foreach(EffectType effect in Enum.GetValues(typeof(EffectType)))
            {
                float probability = effectProbabilities[(int)effect] * EffectManager.getCarcaseFactor(effect, carcase);
                float randomNumber = (float)rand.NextDouble();
                if(randomNumber < probability)
                {
                    effects.Add(EffectManager.createEffect(effect, charm));
                }
            }

            return new Spell(effects, carcase, charm);
        }

    }
}
