using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.game.Potion;
using FMOD.Studio;
using FMODUnity;

public class PotionDragableScript : DragableScript
{
    public EventReference Clank;
    public EventReference Break;
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

                PlaySound(Break, 0.5f, 1);
                if (potionview.IsOnShelf == true)
                {
                    FindObjectOfType<PotionGameloopForOscar>().PotionCracker();
                }


                Destroy(gameObject);
            });

        });
    }

    public override void DoOnGrab()
    {
        PlaySound(Clank, 0.5f, 1);
        potionview.IsOnShelf = true;
        LeanTween.moveLocalZ(potionview.gameObject, -0.2f, 0.1f).setEaseOutSine();
        LeanTween.cancel(gameObject);
        LeanTween.scale(gameObject, Vector3.one * 1.3f, 0.5f).setEasePunch();
    }

    public void PlaySound(EventReference eventotplay, float volume, float pitch)
    {
        var instance = RuntimeManager.CreateInstance(eventotplay);
        instance.set3DAttributes(RuntimeUtils.To3DAttributes(transform.position));
        instance.setVolume(volume);
        instance.setPitch(pitch);
        instance.start();
        instance.release();
    }
}
