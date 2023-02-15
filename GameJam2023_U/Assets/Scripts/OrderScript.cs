using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class OrderScript : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer = null;
    [SerializeField] private int sortingAddition = 0;
    [SerializeField] private bool _doUpdate = false;

    public void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _spriteRenderer.sortingOrder = 32767 - (int)((transform.position.z - Camera.main.transform.position.z) * 100) + sortingAddition;

#if UNITY_EDITOR
        _spriteRenderer = GetComponent<SpriteRenderer>();
#endif
    }



    public void Update()
    {

        if (_doUpdate == true)
        {
            _spriteRenderer.sortingOrder = 32767 - (int)((transform.position.z - Camera.main.transform.position.z) * 100) + sortingAddition;

        }

    }


}
