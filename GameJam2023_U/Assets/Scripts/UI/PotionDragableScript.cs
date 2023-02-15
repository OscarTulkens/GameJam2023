using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.game.Potion;

public class PotionDragableScript : DragableScript
{
    [SerializeField] private GameObject _glassparticles = null;

    [HideInInspector] public PotionView potionview = null;

    private void Awake()
    {
        potionview = GetComponentInChildren<PotionView>();
    }

    public override void DoOnLetGo()
    {
        LeanTween.moveLocalZ(potionview.gameObject, -1.2f, 0.3f).setEaseOutSine();
        transform.localScale = Vector3.one;
        LeanTween.cancel(gameObject);
        LeanTween.moveLocalY(gameObject, gameObject.transform.localPosition.y+2, 0.2f).setEaseOutQuad().setOnComplete(() =>
        {
            LeanTween.moveLocalY(gameObject, gameObject.transform.localPosition.y - 10, 0.6f).setEaseInQuad().setOnComplete(() =>
            {
                Instantiate(_glassparticles, gameObject.transform.position, Quaternion.identity);
                CinemachineShake.Instance.shakeCamera(2, 0.5f, 1);
                Destroy(gameObject);
            });

        });
    }

    public override void DoOnGrab()
    {
        LeanTween.moveLocalZ(potionview.gameObject, -0.2f, 0.1f).setEaseOutSine();
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, Vector3.one * 1.3f, 0.5f).setEasePunch();
    }
}
