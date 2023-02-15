using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTester : MonoBehaviour
{
    public CinemachineShake cinemachineShake;

    private void Start()
    {
        cinemachineShake.shakeCamera(15f, 2f, 2f);
    }
}
