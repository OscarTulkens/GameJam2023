using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.game.Potion;

public class FinalPotionScript : MonoBehaviour, IDraggerTarget
{
    public PotionGameloopForOscar Gameloop;

    public void DoOnDrop(GameObject droppedobject)
    {
        Gameloop.AddThisPotion(droppedobject.GetComponentInChildren<PotionDragableScript>().potionview.mymodel);
    }

}
