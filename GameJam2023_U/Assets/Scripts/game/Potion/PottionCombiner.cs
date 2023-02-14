using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.game.Potion
{

    public static class PottionCombiner
    {

        public static bool CheckCurrentPotionWithTargetPotion(Potion CurrentPotion, Potion targetPotion)
        {
            if (CheckPotionColour(CurrentPotion, targetPotion) &&
                CheckPotionEffect(CurrentPotion, targetPotion) &&
                CheckPotionFoam(CurrentPotion, targetPotion))
            {
                return true;
            }
            else return false;
        }

        private static bool CheckPotionColour(Potion CurrentPotion, Potion targetPotion)
        {
            return CurrentPotion.Potioncolourenum == targetPotion.Potioncolourenum;
        }

        private static bool CheckPotionEffect(Potion CurrentPotion, Potion targetPotion)
        {
            return CurrentPotion.PotionEffect == targetPotion.PotionEffect;
        }

        private static bool CheckPotionFoam(Potion CurrentPotion, Potion targetPotion)
        {
            return CurrentPotion.PotionFoam == targetPotion.PotionFoam;
        }

        public static Potion CombinePotions(Potion CurrentPotion, Potion NewDRaggedPotion)
        {
            var newColor = CombinePotionColour(CurrentPotion, NewDRaggedPotion);
            var combinedFoam = CombinePotionFoam( NewDRaggedPotion);
            var combinedEffect = CombinePotionEffect(CurrentPotion);

            CurrentPotion.Potioncolourenum = newColor;
            CurrentPotion.PotionFoam = combinedFoam;
            CurrentPotion.PotionEffect = combinedEffect;
                        

            return CurrentPotion;
        }

        public static PotionColour CombinePotionColour(Potion CurrentPotion, Potion NewDRaggedPotion)
        {
            var colourCombinations = PotionDatabase.GetColourCombinations();

            var currentPotionColour = CurrentPotion.Potioncolourenum;
            var draggedPotionColour = NewDRaggedPotion.Potioncolourenum;

            foreach (var colorcombination in colourCombinations)
            {
                if (colorcombination.color1 == currentPotionColour && colorcombination.color2 == draggedPotionColour)
                {
                    return colorcombination.resultcolor;
               
                }
                else if (colorcombination.color2 == currentPotionColour && colorcombination.color1 == draggedPotionColour)
                {
                    return colorcombination.resultcolor;
                 
                }
            }

            return PotionColour.black;       
        }

        public static PotionFoamEffect CombinePotionFoam(Potion NewDRaggedPotion)
        {
            return NewDRaggedPotion.PotionFoam;
        }

        public static PotionFoamEffect CombinePotionEffect(Potion CurrentPotion)
        {
            return CurrentPotion.PotionFoam;
        }
    }
}
