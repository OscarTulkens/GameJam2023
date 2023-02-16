using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;
using UnityEngine.UI;
//using FMOD.Studio;
//using FMODUnity;

public class ButtonScript : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private bool _isDisabled = false;

    [SerializeField] private bool _defaultVisible = false;
    [SerializeField] private float _tweenScale = 0;
    [SerializeField] private float _tweenTime = 0;
    [SerializeField] private Image _BackgroundImage = null;

    [SerializeField] private float _appearDelay = 0;
    [SerializeField] private bool _isUnavailable = false;

    [SerializeField] private bool _isButton = true;

    //[SerializeField] private EventReference _clickEvent = new EventReference();
    //[SerializeField] private EventReference _hoverEvent = new EventReference();

    [Space]
    [Header("Background Image")]
    [SerializeField] private Color _selectedColor = Color.white;

    private Vector3 _startScale = Vector3.one;
    private float _scaleFactor = 1.2f;
    
    public bool _isClickable = true;
    public MyEvent buttonEvent = new MyEvent { };

    public void Start()
    {
        //_selectedColor = new Color(255f/255f, 231f/255f,136f/255f);
        _startScale = Vector3.one;

        transform.localScale = Vector3.zero;
        if (_defaultVisible == true)
        {
            LeanTween.delayedCall(_appearDelay, () => LeanTween.scale(gameObject, _startScale, _tweenTime).setEaseOutBack());
        }

        if (_BackgroundImage!=null)
        {
            _BackgroundImage.color = Color.clear;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!_isDisabled && eventData.button == PointerEventData.InputButton.Left)
        {
            if (_isClickable == true && _isButton && _isUnavailable == false)
            {
                //RuntimeManager.PlayOneShot(_clickEvent);
                LeanTween.cancel(gameObject);
                LeanTween.scale(gameObject, _startScale * _tweenScale, _tweenTime).setEasePunch();
                LeanTween.delayedCall(_tweenTime / 3, () => { buttonEvent?.Invoke(); });
                _isClickable = false;
                if (_BackgroundImage != null) _BackgroundImage.color = _selectedColor;
            }
        }
    }

    public void SetClickable(bool clickable)
    {
        _isClickable = clickable;
        //LeanTween.cancel(gameObject);
        if (_BackgroundImage != null) _BackgroundImage.color = Color.clear;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!_isDisabled)
        {
            if (_isButton && _isUnavailable == false)
            {
                LeanTween.cancel(gameObject);
                LeanTween.scale(gameObject, _startScale, _tweenTime).setEaseOutBack();
                if (_BackgroundImage != null) _BackgroundImage.color = Color.clear;
            }
        }

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!_isDisabled)
        {
            if (_isClickable == true && _isButton && _isUnavailable == false)
            {
                //RuntimeManager.PlayOneShot(_hoverEvent);
                LeanTween.cancel(gameObject);
                LeanTween.scale(gameObject, _startScale * _scaleFactor, _tweenTime).setEaseOutBack();
                if (_BackgroundImage != null) _BackgroundImage.color = Color.white;
            }
        }

    }

    public void Appear()
    {
        _isClickable = true;
        _isUnavailable = false;
        if (_BackgroundImage != null) _BackgroundImage.color = Color.clear;
        LeanTween.delayedCall(_appearDelay + 0.5f, () => LeanTween.scale(gameObject, _startScale, _tweenTime).setEaseOutBack());
    }

    public void Disappear()
    {
        _isUnavailable = true;
        _isClickable = false;
        LeanTween.delayedCall(_appearDelay,()=> LeanTween.scale(gameObject, Vector3.zero, _tweenTime).setEaseInBack());
    }

}

[Serializable]
public class MyEvent : UnityEvent { }

