using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPopUpScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, Vector3.one, 0.5f).setEaseOutBack();
    }

}
