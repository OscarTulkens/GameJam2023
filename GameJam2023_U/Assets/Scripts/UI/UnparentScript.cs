using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnparentScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.SetParent(null);
    }
}
