using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class MaskRangeOrderScript : MonoBehaviour
{
    private SpriteMask _spritemask = null;
    [SerializeField] private int sortingAddition = 0;
    [SerializeField] private int sortingRange = 10;
    [SerializeField] private bool _doUpdate = false;

    public void Start()
    {
        _spritemask = GetComponent<SpriteMask>();
        _spritemask.isCustomRangeActive = true;

        _spritemask.backSortingOrder = 32767 - (int)((transform.position.z - Camera.main.transform.position.z) * 100) + sortingAddition - (sortingRange / 2);
        _spritemask.frontSortingOrder = 32767 - (int)((transform.position.z - Camera.main.transform.position.z) * 100) + sortingAddition + (sortingRange / 2);
    }



    public void Update()
    {

        if (_doUpdate == true)
        {
            _spritemask.backSortingOrder = 32767 - (int)((transform.position.z - Camera.main.transform.position.z) * 100) + sortingAddition - (sortingRange / 2);
            _spritemask.frontSortingOrder = 32767 - (int)((transform.position.z - Camera.main.transform.position.z) * 100) + sortingAddition + (sortingRange / 2);

        }

    }
}
