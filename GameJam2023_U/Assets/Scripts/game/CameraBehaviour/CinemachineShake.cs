using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class CinemachineShake : MonoBehaviour
{   

    private CinemachineVirtualCamera cvc;
    private float shaketimer;
    private float Shakeintensity;

    float intensitymultiplyer = 0f;

    public static CinemachineShake Instance = null;

    CinemachineBasicMultiChannelPerlin cmp;
    private void Awake()
    {
        Instance = this;
        cvc = GetComponent<CinemachineVirtualCamera>();
    }

    public void shakeCamera(float intensity, float time, float frequency)
    {
        cmp = cvc.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cmp.m_FrequencyGain = frequency;

        cmp.m_AmplitudeGain = intensity;
        shaketimer = time;
        Shakeintensity = intensity;

        intensitymultiplyer = intensity / shaketimer;
    }

    private void Update()
    {
        if (shaketimer > 0)
        {
            shaketimer -= Time.deltaTime;
            Shakeintensity -= Time.deltaTime * intensitymultiplyer;

            cmp.m_AmplitudeGain = Shakeintensity;

            if (shaketimer <= 0f)
            {              

                cmp.m_AmplitudeGain = 0f;
            }
        }

    }

    private void OnDestroy()
    {
        Instance = null;
    }
}
