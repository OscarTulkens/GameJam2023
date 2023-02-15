using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class ParticleOrderScript : MonoBehaviour
{
    private ParticleSystemRenderer _psr = null;
    [SerializeField] private int _extravalue = 0;
    [SerializeField] private bool _doUpdate = true;
    // Start is called before the first frame update
    private void Start()
    {
        _psr = GetComponent<ParticleSystemRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (_doUpdate)
        {
            _psr.sortingOrder = 32767 - (int)((transform.position.z - Camera.main.transform.position.z) * 100) + _extravalue;
        }

    }
}
