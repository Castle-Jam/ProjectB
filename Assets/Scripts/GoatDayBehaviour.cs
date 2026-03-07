using System.Collections;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class GoatDayBehaviour : MonoBehaviour
{
    [SerializeField] GameObject MilkingMinigame;

    [SerializeField] GoatState goatState;
    bool isMilkable = true;

    float WaitingCounter = 0f;
    enum GoatState
    {
        IDLE,
        WANDER,
        MILKING,
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Do()
    {
        if(WaitingCounter > 0)
        {
            WaitingCounter -= Time.deltaTime;
            return;
        }
        HandleState();
        switch (goatState)
        {
            default:
            case GoatState.IDLE:
                Idle();
                break;
            case GoatState.WANDER:
                HandleWander();
                break;
            case GoatState.MILKING:
                HandleMilking();
                break;

        }
    }

    private void HandleState()
    {
        if (isMilkable)
        {
            HandleMilking();
            isMilkable = false;
            MilkingMinigame.SetActive(true);
        }

    }

    private void Idle()
    {
        float rnd = Random.Range(0.0f, 1.0f);
        if(rnd < 0.3)
        {
            //Find wander spot
        }
        else
        {
            WaitingCounter = 2f;
        }
    }

    private void HandleWander()
    {

    }

    private void HandleMilking()
    {

    }

    public void Wait(float durationSeconds)
    {
        if (durationSeconds <= 0f) return;
        StopAllCoroutines();
        StartCoroutine(PauseCoroutine(durationSeconds));
    }

    private IEnumerator PauseCoroutine(float duration)
    {
        yield return new WaitForSeconds(duration);
    }
}
