using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Scripts.game.Potion;
using UnityEngine;
using UnityEngine.UI;


public class PotionGameloopForOscar : MonoBehaviour
{
    public PotionDatabaseSO databaseSO;
    public Potion OurPotion;
    public GameObject PotionPrefab;
    public PotionView OurPotionView;
    public PotionView TargetPotionView;
    public List<Transform> PotionStartPositions = new List<Transform>();
    private List<GameObject> _shelfPotions = new List<GameObject>();
    public Potion TargetPotion;

    private int _crackCounter = 0;
    //haha
    [SerializeField] private int _maxOverdoses = 3;

    [SerializeField] private Vector3 _winPos = Vector3.zero;

    public TimerCode Timercode;

    public PotionMap Potionmap;

    public Image timervisual;

    private void Start()
    {
        //Timercode.NormalTick += (s, e) =>
        //{
        //    Debug.Log($"NormalTick = CT:{e.CurrentTime} | PA:{e.PotionAmount}");
        //};

        //Timercode.FinalTick += (s, e) =>
        //{
        //    Debug.Log($"FinalTick = CT:{e.CurrentTime} | PA:{e.PotionAmount}");
        //};

        //uitlezen van de Shit uit het scriptablobject en opzetten dictionaries voor ease of use.
        PotionDatabase.InitializePotionDatabase(databaseSO);

        //generen van een unieke kleuencombinatie voor op het board, en ook de rest van de sessie,
        //opnieuw callen be "play again."
        PotionDatabase.GenerateColourCombinations();

        Potionmap.CreatePotionMap();

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


    }

    private void SpawnPotionShelf()
    {
        var generatenewPotionList = PotionDatabase.Generate3PotionPool(OurPotion);

        for (int i = 0; i < 3; i++)
        {
            _shelfPotions.Add(Instantiate<GameObject>(PotionPrefab, PotionStartPositions[i]));
            generatenewPotionList[i].InitPotionview(_shelfPotions[i].GetComponentInChildren<PotionDragableScript>().potionview);
        }
    }

    private void DestroyPotionShelf()
    {
        foreach (GameObject potion in _shelfPotions)
        {
            if (potion!=null)
            {
                potion.GetComponentInChildren<PotionDragableScript>().DoOnLetGo();
            }

        }

        _shelfPotions.Clear();
    }

    private void Update()
    {
        timervisual.fillAmount = Timercode.sliderDivision;
    }

    public void AddThisPotion(GameObject draggedpotionobject)
    {
        Timercode.ResetAndGetNextTimer();

        _shelfPotions.Remove(draggedpotionobject);

        Potion draggedpotionmodel = draggedpotionobject.GetComponentInChildren<PotionDragableScript>().potionview.mymodel;

        PottionCombiner.CombinePotions(OurPotion, draggedpotionmodel);
        OurPotion.updatePotionView();

        //check victory condition
        bool didWeWin = PottionCombiner.CheckCurrentPotionWithTargetPotion(OurPotion, TargetPotion);

        // if we didnt win we generate 3 new potions on the shelve.
        if (!didWeWin)
        {
            if (OurPotion.Potioncolourenum == PotionColour.black)
            {
                WinLoseScript.Instance.Lose();
            }
            DestroyPotionShelf();
            SpawnPotionShelf();

        }
        else
        {
            Timercode.StopTimer();
            DestroyPotionShelf();
            WinLoseScript.Instance.Win();
            //gameover
            //op dit moment is de potion al zwart geworden ( de laatste kleur in de potioncolour enum.
            //animation + potion breakage ig 

        }
    }
}

