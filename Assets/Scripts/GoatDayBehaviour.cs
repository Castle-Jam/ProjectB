using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class GoatDayBehaviour : MonoBehaviour
{
    [SerializeField] GameObject MilkingMinigame;

    private MilkingMinigame milkingMini;

    [SerializeField] GoatState goatDayState;
    [SerializeField] public float wanderRadius = 10f;

    UnityEngine.Vector3 goalPos;
    UnityEngine.Vector3 fuckY = new UnityEngine.Vector3(1.0f, 0.0f, 1.0f);
    UnityEngine.Vector3 FlatPosition => new Vector3(transform.position.x, 0, transform.position.z);

    bool isMilkable = true;

    float WaitingCounter = 0f;
    enum GoatState{IDLE, WANDER, MILKING,}

    private Unit unitScript;
    private CustomGrid gridScript;

    void Awake()
    {
        unitScript = GetComponent<Unit>();
        gridScript = GetComponent<CustomGrid>();

        if (gridScript == null)
            gridScript = FindFirstObjectByType<CustomGrid>();
        if (unitScript == null)
            Debug.LogError("No Unit component found on " + gameObject.name);
        if (gridScript == null)
            Debug.LogError("No CustomGrid found anywhere in scene");
    }

    public void Do()
    {
        if(WaitingCounter > 0)
        {
            WaitingCounter -= Time.deltaTime;
            return;
        }
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
                if (isMilkable)
                    HandleMilking();
                break;

        }
    }


    private void Idle()
    {
        float rnd = Random.Range(0.0f, 1.0f);
        Debug.Log("Idle rolled: " + rnd);
        if(rnd < 0.3)
        {
            Vector3 candidate = GetRandomPosition();
            Debug.Log("Requesting path to: " + goalPos);
            if (candidate == FlatPosition)
            {
                WaitingCounter = 2f;
                return;
            }
            goalPos = candidate;
            PathRequestManager.RequestPath(transform.position, goalPos, unitScript.OnPathFound);
            goatDayState = GoatState.WANDER;
        }
        else
        {
            WaitingCounter = 4f;
        }
    }

    UnityEngine.Vector3 GetRandomPosition()
    {
        // Adding a safety Net
        int maxAttempts = 10;
        for (int i = 0; i < maxAttempts; i++)
        {
            // create a random position within a radius around object
            UnityEngine.Vector2 random = Random.insideUnitCircle * wanderRadius;
            Vector3 candidate = FlatPosition + new Vector3(random.x, 0, random.y);

            if (!gridScript.IsWithinBounds(candidate))
                continue;

            Node node = gridScript.NodeFromWorldPoint(candidate);
            if (node != null && node.walkable)
            {
                Debug.Log("Good Area to Walk to");
                return candidate;
            }
        }
        Debug.LogWarning("No Walkable position found after " + maxAttempts + " attempts");
        return FlatPosition;
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
        goatDayState = GoatState.MILKING;
    }

    private void Milking()
    {
        MilkingMinigame.SetActive(true);
        bool minigameRunning = true;

        while (minigameRunning)
        {
            transform.position = transform.position;
            minigameRunning = milkingMini.GetStatus();
        }

    }

    public void OnPathFailed()
    {
        Debug.Log("Path failed, returning to IDLE");
        goatDayState = GoatState.IDLE;
        WaitingCounter = 2f;
    }
}