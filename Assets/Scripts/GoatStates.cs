using System;
using UnityEngine;

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
