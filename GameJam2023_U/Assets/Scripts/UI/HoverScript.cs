using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverScript : MonoBehaviour
{
    [SerializeField] private float _height = 0;
    [SerializeField] private float _time = 0;
    // Start is called before the first frame update
    void Start()
    {
        LeanTween.moveLocalY(gameObject, transform.localPosition.y + _height, _time).setEaseInOutSine().setLoopPingPong();
    }
}
