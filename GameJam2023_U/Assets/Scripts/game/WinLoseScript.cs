using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Febucci.UI;
using TMPro;
using UnityEngine.Rendering;

public class WinLoseScript : MonoBehaviour
{
    public static WinLoseScript Instance = null;
    [SerializeField] private string _winString = null;
    [SerializeField] private string _loseString = null;
    [SerializeField] private TextAnimatorPlayer text  = null;
    [SerializeField] private Volume _winVolume = null;
    [SerializeField] private Volume _loseVolume = null;
    [SerializeField] private ButtonScript endbutton = null;

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        text.ShowText("");
    }

    private void OnDestroy()
    {
        Instance = null;
    }

    public void Lose()
    {
        LeanTween.value(0, 1, 2f).setEaseInOutSine().setOnUpdate((float val) => { _winVolume.weight = val; }).setOnComplete(() =>
        {
            endbutton.Appear();
        });
        LeanTween.delayedCall(1, () => text.ShowText("<wave>" + _loseString));
    }

    public void Win()
    {
        LeanTween.value(0, 1, 2f).setEaseInOutSine().setOnUpdate((float val) => { _loseVolume.weight = val; }).setOnComplete(() =>
        {
            endbutton.Appear();
        });
        LeanTween.delayedCall(1, () => text.ShowText("<wave>" + _winString));
        
    }
}
