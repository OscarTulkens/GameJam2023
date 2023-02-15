using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundDraggerTarget : MonoBehaviour, IDraggerTarget
{

    [SerializeField] private float _killHeight = -10;
    [SerializeField] private float _fallSpeed = 5;

    private GameObject _fallingobject = null; 
    public void DoOnDrop(GameObject droppedobject)
    {
        Debug.Log("DROPPED ON " + droppedobject.name);
        _fallingobject = droppedobject;
    }

    // Update is called once per frame
    void Update()
    {
        if (_fallingobject != null)
        {
            _fallingobject.transform.position -= new Vector3(0,Time.deltaTime*_fallSpeed,0);
            if (_fallingobject.transform.position.y<=_killHeight)
            {
                Destroy(_fallingobject);
                _fallingobject = null;
            }
        }

    }
}
