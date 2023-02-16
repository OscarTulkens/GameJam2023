using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.game.Potion;

public class FinalPotionDraggerTargetScript : MonoBehaviour, IDraggerTarget
{
    public PotionGameloopForOscar Gameloop;
    public GameObject BoopObject;

    public void DoOnDrop(GameObject droppedobject)
    {
        Gameloop.AddThisPotion(droppedobject);
        Boop();
        RemoveDroppedObject(droppedobject);
    }

    public void Boop()
    {
        LeanTween.cancel(BoopObject);
        LeanTween.scale(BoopObject, Vector3.one * 1.3f, 0.5f).setEasePunch();
    }

    public void RemoveDroppedObject(GameObject droppedobject)
    {
        LeanTween.scale(droppedobject.GetComponentInChildren<PotionDragableScript>().potionview.gameObject, Vector3.zero, 0.75f).setEaseOutQuad();
        LeanTween.rotate(droppedobject.GetComponentInChildren<PotionDragableScript>().potionview.gameObject, new Vector3(0,0,1440), 0.75f).setEaseOutQuad().setOnComplete(()=>Destroy(droppedobject));
    }

}
