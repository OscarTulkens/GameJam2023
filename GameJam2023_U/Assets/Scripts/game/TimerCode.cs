using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerCode : MonoBehaviour
{
    public AnimationCurve TimerCurve;

    public int PotionNumber = 0;

    public List<float> TimerIntervals = new List<float>();

    private void Start()
    {
        for (int i = 0; i < 21; i++)
        {
            TimerIntervals.Add(TimerCurve.Evaluate(i));
        }
    }

    public float GetNextTimeInterval()
    {
        float intervalToReturn = 10;

        if (PotionNumber < TimerIntervals.Count)
        {
            intervalToReturn = TimerIntervals[PotionNumber];
        }
        else
        {
            intervalToReturn = TimerIntervals[TimerIntervals.Count - 1];
        }

        PotionNumber++;

        //Debug.Log($"{PotionNumber} + {intervalToReturn}");

        return intervalToReturn;
    }
}
