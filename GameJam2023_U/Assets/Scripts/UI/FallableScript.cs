using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallableScript : MonoBehaviour
{
    [SerializeField] Vector2 _startMoveVector = Vector2.zero;
    [SerializeField] float _downwardsAccelerator = 0;
    private bool _isfalling = false;
    private Vector2 _movingVector = Vector2.zero;
    // Start is called before the first frame update
    public void Fall()
    {
        _isfalling = true;
    }

    public void StopFall()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_isfalling == true)
        {

        }
    }
}
