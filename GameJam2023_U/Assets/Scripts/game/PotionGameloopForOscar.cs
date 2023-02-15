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
    public Potion OurPotion;
    public GameObject PotionPrefab;
    public PotionView OurPotionView;
    public PotionView TargetPotionView;
    public List<Transform> PotionStartPositions = new List<Transform>();
    public Potion TargetPotion;

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
        OurPotion = PotionDatabase.generateTargetPotionModel();
        TargetPotion = PotionDatabase.generateStartingPotionModel(OurPotion);
        //initialze de view (in deze code moeten de pots wel nog instanciated worden, up too you) 
        OurPotion.InitPotionview(OurPotionView);
        TargetPotion.InitPotionview(TargetPotionView);

        SpawnPotionShelf();

        //------------------------------------------------------------------------------------------------------

        //templatecode voor spelen van een potion loop

        //potion die gedragt wordt, nu efkes een base one gemaakt.
        var fakepot = new Potion(PotionColour.Red, PotionFoamEffect.foam1, PotionFoamEffect.foam1);

        //combine dragged potion with current potion
        //dit past enkel de model aan, je moet de view nog opnieuwmakes/updaten
        


    }

    private void SpawnPotionShelf()
    {
        var generatenewPotionList = PotionDatabase.Generate3PotionPool(OurPotion);

        for (int i = 0; i < 3; i++)
        {
            GameObject potview3 = Instantiate<GameObject>(PotionPrefab, PotionStartPositions[i]);
            generatenewPotionList[i].InitPotionview(potview3.GetComponentInChildren<PotionDragableScript>().potionview);
        }
    }


    public void AddThisPotion(Potion draggedpotion)
    {
        PottionCombiner.CombinePotions(OurPotion, draggedpotion);
        OurPotion.updatePotionView();

        //check victory condition
        bool didWeWin = PottionCombiner.CheckCurrentPotionWithTargetPotion(OurPotion, TargetPotion);

        // if we didnt win we generate 3 new potions on the shelve.
        if (!didWeWin)
        {
            //SpawnPotionShelf();
        }
        else
        {
            //gameover
            //op dit moment is de potion al zwart geworden ( de laatste kleur in de potioncolour enum.
            //animation + potion breakage ig 

        }
    }
}

