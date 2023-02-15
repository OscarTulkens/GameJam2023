using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAsWellScript : MonoBehaviour
{
    [SerializeField] private GameObject _ifDestroyedObject = null;

    // Update is called once per frame
    void Update()
    {
        if (_ifDestroyedObject == null)
        {
            Destroy(this.gameObject);
        }
    }
}
