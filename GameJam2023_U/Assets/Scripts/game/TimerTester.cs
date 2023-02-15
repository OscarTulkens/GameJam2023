using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTester : MonoBehaviour
{
    public TimerCode timercode;

    private void Start()
    {
        timercode.NormalTick += (s, e) =>
        {
            Debug.Log($"NormalTick = CT:{e.CurrentTime} | PA:{e.PotionAmount}");
        };

        timercode.FinalTick += (s, e) =>
        {
            Debug.Log($"FinalTick = CT:{e.CurrentTime} | PA:{e.PotionAmount}");
        };
    }
}
