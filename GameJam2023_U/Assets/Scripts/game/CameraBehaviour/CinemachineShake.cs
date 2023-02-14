using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class CinemachineShake : MonoBehaviour
{
    //public static CinemachineShake Instance { get; private set; }

    //private CinemachineVirtualCamera cvc;
    //private float shaketimer;
    //private void Awake()
    //{
    //    Instance = this;
    //    cvc = GetComponent<CinemachineVirtualCamera>();
    //}

    //public void shakeCamera(float intensity, float time)
    //{
    //    CinemachineBasicMultiChannelPerlin cmp = cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    //    cmp.m_AmplitudeGain = intensity;

    //    shaketimer = time;
    //}

    //private void Update()
    //{
    //    if (shaketimer > 0)
    //    {
    //        shaketimer -= Time.deltaTime;
    //        if (shaketimer <= 0f)
    //        {
    //            CinemachineBasicMultiChannelPerlin cmp = cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

    //            cmp.m_AmplitudeGain = 0f;
    //        }
    //    }

    //}
}
