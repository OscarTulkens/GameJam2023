using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseCamScript : MonoBehaviour
{
    [SerializeField] private GameObject _raisedCamPoint;
    private void Update()
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