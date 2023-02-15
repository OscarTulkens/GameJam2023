using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.game.Potion;

public class PotionDragableScript : DragableScript
{
    [SerializeField] Vector2 _startMoveVector = Vector2.zero;
    [SerializeField] float _downwardsAccelerator = 0;
    private bool _isfalling = false;
    private Vector2 _movingVector = Vector2.zero;

    public PotionView potionview = null;

    private void Awake()
    {
        potionview = GetComponentInChildren<PotionView>();
    }

    public override void DoOnLetGo()
    {
        transform.localScale = Vector3.one;
        LeanTween.cancel(gameObject);
        LeanTween.moveLocalY(gameObject, gameObject.transform.localPosition.y+2, 0.2f).setEaseOutQuad().setOnComplete(() =>
        {
            LeanTween.moveLocalY(gameObject, gameObject.transform.localPosition.y - 15, 0.6f).setEaseInQuad().setOnComplete(()=>Destroy(gameObject));

        });
    }

    public override void DoOnGrab()
    {
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, Vector3.one * 1.3f, 0.5f).setEasePunch();
    }
}
