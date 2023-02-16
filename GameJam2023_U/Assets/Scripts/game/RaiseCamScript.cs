using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseCamScript : MonoBehaviour
{
    [SerializeField] private GameObject _raisedCamPoint;
    [SerializeField] private bool _hasStarted = false;

    private void Start()
    {
        LeanTween.delayedCall(2, () =>
        {
            _hasStarted = true;
            _raisedCamPoint.SetActive(false);
        });
    }

    private void Update()
    {
        if (_hasStarted == true)
        {
            if (Input.GetMouseButtonDown(1))
            {
                _raisedCamPoint.SetActive(true);
            }
            if (Input.GetMouseButtonUp(1))
            {
                _raisedCamPoint.SetActive(false);
            }
        }

    }
}
