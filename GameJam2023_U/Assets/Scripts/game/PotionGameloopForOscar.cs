using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.game.Potion;
using UnityEngine;


public class PotionGameloopForOscar : MonoBehaviour
{
    public PotionDatabaseSO databaseSO;
    public Potion Currentpotion;
    public PotionView potionviewTemplate;
    public Transform potviewparent;

    private void Start()
    {
        //uitlezen van de Shit uit het scriptablobject en opzetten dictionaries voor ease of use.
        PotionDatabase.InitializePotionDatabase(databaseSO);

        //generen van een unieke kleuencombinatie voor op het board, en ook de rest van de sessie,
        //opnieuw callen be "play again."
        PotionDatabase.GenerateColourCombinations();

        //get list of combos, te displayen op de color combination Board, wordt dus gebruikt voor de checks etc.
        List<ColorCombination> combinationlist = PotionDatabase.GetColourCombinations();
        Debug.Log($"{PotionDatabase.GetPotionColourFromEnum(combinationlist[0].color1)} + {PotionDatabase.GetPotionColourFromEnum(combinationlist[0].color2)} = {PotionDatabase.GetPotionColourFromEnum(combinationlist[0].resultcolor)}");

        //genereren van de target en startingpotion
        Potion startinPotion = PotionDatabase.generateTargetPotionModel();
        Currentpotion = startinPotion;
        Potion TargetPotion = PotionDatabase.generateStartingPotionModel(startinPotion);
        //initialze de view (in deze code moeten de pots wel nog instanciated worden, up too you) 
        PotionView potview = Instantiate<PotionView>(potionviewTemplate, potviewparent);
        startinPotion.InitPotionview(potview);
        PotionView potview2 = Instantiate<PotionView>(potionviewTemplate, potviewparent);
        TargetPotion.InitPotionview(potview2);

        //------------------------------------------------------------------------------------------------------

        //templatecode voor spelen van een potion loop

        //potion die gedragt wordt, nu efkes een base one gemaakt.
        new Potion(PotionColour.Red, PotionFoamEffect.foam1, PotionFoamEffect.foam1);

        //combine dragged potion with current potion
        //dit past enkel de model aan, je moet de view nog opnieuwmakes/updaten
        PottionCombiner.CombinePotions(Currentpotion, TargetPotion);
        Currentpotion.updatePotionView();

        //check victory condition
        bool didWeWin = PottionCombiner.CheckCurrentPotionWithTargetPotion(Currentpotion, TargetPotion);

        // if we didnt win we generate 3 new potions on the shelve.
        if (!didWeWin)
        {
            var generatenewPotionList = PotionDatabase.Generate3PotionPool(Currentpotion);

            foreach (var potion in generatenewPotionList)
            {
                PotionView potview3 = Instantiate<PotionView>(potionviewTemplate, potviewparent);
                potion.InitPotionview(potview3);
            }
        }
        else
        {
            //gameover
            //op dit moment is de potion al zwart geworden ( de laatste kleur in de potioncolour enum.
            //animation + potion breakage ig 

        }


    }

}

