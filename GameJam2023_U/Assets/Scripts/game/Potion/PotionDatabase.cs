using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.game.Potion
{
    public static class PotionDatabase
    {
        public static Dictionary<PotionColour, Color> colours = new Dictionary<PotionColour, Color>();
        public static Dictionary<PotionFoamEffect, GameObject> effects = new Dictionary<PotionFoamEffect, GameObject>();
        public static Dictionary<PotionFoamEffect, Sprite> foams = new Dictionary<PotionFoamEffect, Sprite>();


        public static List<ColorCombination> ColourCombinationList = new List<ColorCombination>();

        //deze code werd gedicteerd door ruben
        public static List<ColorCombination> GetColourCombinations()
        {
            return ColourCombinationList;
        }

        public static void GenerateColourCombinations()
        {
            //List<List<PotionColour>> colourListList = new List<List<PotionColour>>();

            //for (int i = 0; i < 5; i++)
            //{
            //    List<PotionColour> colourList = new List<PotionColour>();
            //    colourList.Add(PotionColour.Red);
            //    colourList.Add(PotionColour.Yellow);
            //    colourList.Add(PotionColour.Green);
            //    colourList.Add(PotionColour.Blue);
            //    colourList.Add(PotionColour.Purple);

            //    colourList.Shuffle();

            //    colourListList.Add(colourList);
            //}

            //var CL1 = colourListList[0];
            //var CL2 = colourListList[1];
            //var CL3 = colourListList[2];
            //var CL4 = colourListList[3];
            //var CL5 = colourListList[4];

            //ColorCombination combination1 = new ColorCombination(CL1[0], CL1[1], CL1[2]);

            //CL2.Remove(combination1.resultcolor);
            //ColorCombination combination2 = new ColorCombination(combination1.resultcolor, CL2[0], CL2[1]);

            //CL3.Remove(combination2.resultcolor);
            //ColorCombination combination3 = new ColorCombination(combination2.resultcolor, CL3[0], CL3[1]);

            List<PotionColour> colourList = new List<PotionColour>();
            colourList.Add(PotionColour.Red);
            colourList.Add(PotionColour.Yellow);
            colourList.Add(PotionColour.Green);
            colourList.Add(PotionColour.Blue);
            colourList.Add(PotionColour.Purple);

            colourList.Shuffle();

            ColourCombinationList.Add(new ColorCombination(colourList[1], colourList[2], colourList[0]));
            ColourCombinationList.Add(new ColorCombination(colourList[0], colourList[1], colourList[1]));
            ColourCombinationList.Add(new ColorCombination(colourList[2], colourList[4], colourList[2]));
            ColourCombinationList.Add(new ColorCombination(colourList[3], colourList[0], colourList[3]));
            ColourCombinationList.Add(new ColorCombination(colourList[3], colourList[4], colourList[4]));

            ColourCombinationList.Shuffle();
        }



        public static List<Potion> Generate3PotionPool(Potion currentPotion)
        {
            List<Potion> pool = new List<Potion>();

            var colour = currentPotion.Potioncolourenum;

            PotionColour colorWeNeed = PotionColour.Red;

            ColourCombinationList.Shuffle();

            foreach (var colorcombination in ColourCombinationList)
            {
                if (colorcombination.color1 == colour)
                {
                    colorWeNeed = colorcombination.color2;
                    break;
                }
                else if (colorcombination.color2 == colour)
                {
                    colorWeNeed = colorcombination.color1;
                    break;
                }
            }

            PotionFoamEffect foam = (PotionFoamEffect)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(PotionFoamEffect)).Length);
            PotionFoamEffect effect = (PotionFoamEffect)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(PotionFoamEffect)).Length);

            pool.Add(new Potion(colorWeNeed, foam, effect));

            PotionColour colour2 = (PotionColour)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(PotionColour)).Length - 1);
            PotionFoamEffect foam2 = (PotionFoamEffect)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(PotionFoamEffect)).Length);
            PotionFoamEffect effect2 = (PotionFoamEffect)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(PotionFoamEffect)).Length);

            pool.Add(new Potion(colour2, foam2, effect2));

            PotionColour colour3 = (PotionColour)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(PotionColour)).Length - 1);
            PotionFoamEffect foam3 = (PotionFoamEffect)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(PotionFoamEffect)).Length);
            PotionFoamEffect effect3 = (PotionFoamEffect)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(PotionFoamEffect)).Length);

            pool.Add(new Potion(colour3, foam3, effect3));

            pool.Shuffle();

            return pool;
        }


        public static Potion generateTargetPotionModel()
        {

            PotionColour colour = (PotionColour)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(PotionColour)).Length - 1);
            PotionFoamEffect foam = (PotionFoamEffect)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(PotionFoamEffect)).Length);
            PotionFoamEffect effect = (PotionFoamEffect)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(PotionFoamEffect)).Length);

            return new Potion(colour, foam, effect);

            //Potion targetPotion = new Potion();
        }

        public static Potion generateStartingPotionModel(Potion targetPotion)
        {
            PotionColour colour = (PotionColour)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(PotionColour)).Length -1);
            while (targetPotion.Potioncolourenum == colour)
            {
                colour = (PotionColour)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(PotionColour)).Length);
            }

            PotionFoamEffect foam = (PotionFoamEffect)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(PotionFoamEffect)).Length);
            while(targetPotion.PotionFoam == foam)
            {
                foam = (PotionFoamEffect)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(PotionFoamEffect)).Length);
            }

            PotionFoamEffect effect = (PotionFoamEffect)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(PotionFoamEffect)).Length);
            while (targetPotion.PotionEffect == effect)
            {
                effect = (PotionFoamEffect)UnityEngine.Random.Range(0, System.Enum.GetValues(typeof(PotionFoamEffect)).Length);
            }

            return new Potion(colour, foam, effect);
        }



        public static void InitializePotionDatabase(PotionDatabaseSO database)
        {
            foreach (var item in database.colourRelations)
            {
                colours.Add(item.potioncolour, item.color);
            }

            foreach (var item in database.Effectrelation)
            {
                effects.Add(item.potionEffect, item.EffectImage);
            }

            foreach (var item in database.foamrelation)
            {
                foams.Add(item.potionFoam, item.FoamImage);
            }
        }

        public static Color GetPotionColourFromEnum(PotionColour potionoclour)
        {
            if (colours.TryGetValue(potionoclour, out var colour))
                return colour;

            else
            {
                Debug.Log("color not found");
                return Color.gray;

            }
        }

        public static GameObject GetPotionEffect(PotionFoamEffect potionEffect)
        {
            if (effects.TryGetValue(potionEffect, out var effect))
                return effect;

            else
            {
                Debug.Log("effecrt not found");
                return null;
            }
        }

        public static Sprite GetPotionFoam(PotionFoamEffect potionFoam)
        {
            if (foams.TryGetValue(potionFoam, out var foam))
                return foam;

            else
            {
                Debug.Log("foam not found");
                return null;
            }
        }
    }


}
