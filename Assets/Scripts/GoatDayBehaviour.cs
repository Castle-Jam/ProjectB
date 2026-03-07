using System.Collections;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class GoatDayBehaviour : MonoBehaviour
{
    [SerializeField] GameObject MilkingMinigame;

    [SerializeField] GoatState goatDayState;
    [SerializeField] public float wanderRadius = 10f;
    bool isMilkable = true;

    float WaitingCounter = 0f;
    enum GoatState{IDLE, WANDER, MILKING,}

    private Unit otherScript;

    void Awake()
    {
        otherScript = GetComponent<Unit>();
    }

    public void Do()
    {
        if(WaitingCounter > 0)
        {
            WaitingCounter -= Time.deltaTime;
            return;
        }
        HandleState();
        switch (goatDayState)
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
            Vector3 randomPosVec3 = GetRandomPosition();
            PathRequestManager.RequestPath(transform.position, randomPosVec3, otherScript.OnPathFound);
        }
        else
        {
            WaitingCounter = 2f;
        }
    }

    Vector3 GetRandomPosition()
    {
        // create a random position within a radius around object
        Vector2 random = Random.insideUnitCircle * wanderRadius;
        return transform.position + new Vector3(random.x, 0, random.y);
    }

    private void HandleWander()
    {
        
    }

    private void HandleMilking()
    {

    }
}