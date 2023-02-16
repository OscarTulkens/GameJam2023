using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerEventArgs : EventArgs
{
    public int CurrentTime { get; }

    public int PotionAmount { get; }

    public TimerEventArgs(int currentTime, int potionAmount)
    {
        CurrentTime = currentTime;
        PotionAmount = potionAmount;
    }
}
public class TimerCode : MonoBehaviour
{
    public AnimationCurve TimerCurve;

    private int PotionNumber = 0;

    public List<int> TimerIntervals = new List<int>();

    float CurrentTime = 0;
    private int CurrentTimeIntervall;

    public float sliderDivision { get => CurrentTime / CurrentTimeIntervall; }

    int lastintcrossed = 0;

    private void Awake()
    {
        for (int i = 0; i < 15; i++)
        {
            TimerIntervals.Add(Mathf.RoundToInt(TimerCurve.Evaluate(i)));
        }

        CurrentTimeIntervall = GetNextTimeInterval();
    }

    public void StopTimer()
    {
        LeanTween.scale(gameObject, Vector3.zero, 0.5f).setEaseOutBack();
        gameObject.SetActive(false);
    }

    public int GetNextTimeInterval()
    {
        int intervalToReturn = 0;

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

    private void Update()
    {
        CurrentTime += Time.deltaTime;

        if (CurrentTime > lastintcrossed && lastintcrossed < CurrentTimeIntervall)
        {
            lastintcrossed++;
            
            OnNormalTick(new TimerEventArgs(lastintcrossed, PotionNumber));
           
        }

        if (CurrentTime >= CurrentTimeIntervall)
        {
            CurrentTimeIntervall = GetNextTimeInterval();

            OnFinalTick(new TimerEventArgs(CurrentTimeIntervall, PotionNumber));
           
            lastintcrossed = 0;
            CurrentTime = 0;
        }
    }

    public void ResetAndGetNextTimer()
    {
        CurrentTimeIntervall = GetNextTimeInterval();

        //OnFinalTick(new TimerEventArgs(CurrentTimeIntervall, PotionNumber));

        lastintcrossed = 0;
        CurrentTime = 0;
    }

    public event EventHandler<TimerEventArgs> NormalTick;
    public event EventHandler<TimerEventArgs> FinalTick;

    protected virtual void OnNormalTick(TimerEventArgs eventargs)
    {
        var handler = NormalTick;
        handler?.Invoke(this, eventargs);
    }

    protected virtual void OnFinalTick(TimerEventArgs eventargs)
    {
        var handler = FinalTick;
        handler?.Invoke(this, eventargs);
    }
}
