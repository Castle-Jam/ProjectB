using UnityEngine;
using UnityEngine.UIElements;


public class GoatDayBehaviour : MonoBehaviour
{
    [SerializeField] GameObject MilkingMinigame;

    [SerializeField] GoatState goatDayState;
    [SerializeField] public float wanderRadius = 10f;

    UnityEngine.Vector3 goalPos;
    UnityEngine.Vector3 fuckY = new UnityEngine.Vector3(1.0f, 0.0f, 1.0f);
    UnityEngine.Vector3 FlatPosition => new Vector3(transform.position.x, 0, transform.position.z);

    bool isMilkable = true;

    float WaitingCounter = 0f;
    enum GoatState{IDLE, WANDER, MILKING,}

    private Unit otherScript;

    void Awake()
    {
        otherScript = GetComponent<Unit>();
        if (otherScript == null)
            Debug.Log("No Unit component found on " + gameObject.name);
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
        Debug.Log("Idle rolled: " + rnd);
        if(rnd < 0.3)
        {
            goalPos = GetRandomPosition();
            Debug.Log("Requesting path to: " + goalPos);
            PathRequestManager.RequestPath(transform.position, goalPos, otherScript.OnPathFound);
            goatDayState = GoatState.WANDER;
        }
        else
        {
            WaitingCounter = 4f;
        }
    }

    UnityEngine.Vector3 GetRandomPosition()
    {
        // create a random position within a radius around object
        UnityEngine.Vector2 random = Random.insideUnitCircle * wanderRadius;
        return FlatPosition + new UnityEngine.Vector3(random.x, 0, random.y);
    }

    private void HandleWander()
    {
        float dist = Vector3.Distance(FlatPosition, goalPos);
        Debug.Log("Distance to goal: " + dist + " | FlatPos: " + FlatPosition + " | Goal: " + goalPos);

        if (UnityEngine.Vector3.Distance(FlatPosition, goalPos) < 2.0f)
            goatDayState = GoatState.IDLE;
    }

    private void HandleMilking()
    {

    }
}