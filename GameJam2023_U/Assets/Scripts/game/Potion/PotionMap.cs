using Assets.Scripts.game.Potion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PotionMap : MonoBehaviour
{
   public List<PotionCombinationView> PotionCombinationView = new List<PotionCombinationView>();

    public void CreatePotionMap()
    {
        List<ColorCombination> potionCombinations = PotionDatabase.ColourCombinationList;

        for (int i = 0; i < potionCombinations.Count; i++)
        {
            ColorCombination combination = potionCombinations[i];
            PotionCombinationView potcombview = PotionCombinationView[i];
            potcombview.potionCombinationColour1.color = PotionDatabase.GetPotionColourFromEnum(combination.color1);
            potcombview.potionCombinationColour2.color = PotionDatabase.GetPotionColourFromEnum(combination.color2);
            potcombview.potionCombinationResult.color = PotionDatabase.GetPotionColourFromEnum(combination.resultcolor);
        }
    }
}
