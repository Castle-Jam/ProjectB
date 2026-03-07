using System;
using UnityEngine;
using UnityEngine.Events;

public class GoatStates : MonoBehaviour
{
    private GoatDayBehaviour goatDayBehaviour;
    private GoatNightBehaviour goatNightBehaviour;

    public enum GoatState {DAY, NIGHT};
    private GoatState goatState;


    void Start()
    {
        goatDayBehaviour = GetComponent<GoatDayBehaviour>();
        goatNightBehaviour = GetComponent<GoatNightBehaviour>();
        CustomEvent.DayStarted.AddListener(SwitchToDayBehaviour);
        CustomEvent.NightStarted.AddListener(SwitchToNightBehaviour);
    }

    void SwitchToDayBehaviour()
    {
        goatState = GoatState.DAY;
    }
    void SwitchToNightBehaviour()
    {
        goatState = GoatState.NIGHT;
    }

    private void OnDestroy()
    {
        CustomEvent.DayStarted.RemoveAllListeners();
        CustomEvent.NightStarted.RemoveAllListeners();
    }

    void Update()
    {
        switch (goatState)
        {
            case GoatState.DAY:
                goatDayBehaviour.Do();
                break;
            case GoatState.NIGHT:
                goatNightBehaviour.Do();
                break;
        }
    }
}