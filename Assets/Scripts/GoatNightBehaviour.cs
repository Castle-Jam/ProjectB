using UnityEngine;

public class GoatNightBehaviour : MonoBehaviour
{
    [SerializeField] GoatState goatNightState;
    [SerializeField] public float searchRadius = 10f;
    [SerializeField] public Transform playerTransform;
    Vector3 goalPos;
    Vector3 FlatPosition => new Vector3(transform.position.x, 0, transform.position.z);

    float pathRequestCooldown = 0f;
    [SerializeField] float pathRequestInterval = 0.5f;

    enum GoatState { SEARCH, WALKING, CHASE }

    private Unit unitScript;
    private CustomGrid gridScript;
    private Transform Player;
    [SerializeField] private int detectionRange;

    void Awake()
    {
        unitScript = GetComponent<Unit>();
        gridScript = GetComponent<CustomGrid>();
        Player = GameObject.FindWithTag("Player").transform;

        if (gridScript == null)
            gridScript = FindFirstObjectByType<CustomGrid>();
        if (unitScript == null)
            Debug.LogError("No Unit component found on " + gameObject.name);
        if (gridScript == null)
            Debug.LogError("No CustomGrid found anywhere in scene");
    }

    public void Do()
    {
        float distanceToPlayer = Vector3.Distance(Player.position, transform.position);

        if (distanceToPlayer <= detectionRange)
        {
            if (goatNightState != GoatState.CHASE)
            {
                goatNightState = GoatState.CHASE;
                pathRequestCooldown = 0f;
            }
        }
        else
        {
            if (goatNightState == GoatState.CHASE)
            {
                goatNightState = GoatState.SEARCH;
            }
        }

        pathRequestCooldown -= Time.deltaTime;

        switch (goatNightState)
        {
            default:
            case GoatState.SEARCH:
                Search();
                break;
            case GoatState.WALKING:
                HandleWander();
                break;
            case GoatState.CHASE:
                Chase();
                break;
        }
    }

    private void Search()
    {
        if (pathRequestCooldown > 0f) return;

        Vector3 candidate = GetRandomPosition();
        if (candidate == FlatPosition) return;

        goalPos = candidate;
        PathRequestManager.RequestPath(transform.position, goalPos, unitScript.OnPathFound);
        goatNightState = GoatState.WALKING;

        pathRequestCooldown = pathRequestInterval;
    }

    private void Chase()
    {
        if (pathRequestCooldown > 0f) return;

        PathRequestManager.RequestPath(transform.position, Player.position, unitScript.OnPathFound);
        pathRequestCooldown = pathRequestInterval;
    }

    private void HandleWander()
    {
        if (Vector3.Distance(FlatPosition, goalPos) < 2.0f)
            goatNightState = GoatState.SEARCH;
    }

    Vector3 GetRandomPosition()
    {
        int maxAttempts = 10;
        for (int i = 0; i < maxAttempts; i++)
        {
            Vector2 random = Random.insideUnitCircle * searchRadius;
            Vector3 candidate = FlatPosition + new Vector3(random.x, 0, random.y);

            if (!gridScript.IsWithinBounds(candidate)) continue;

            Node node = gridScript.NodeFromWorldPoint(candidate);
            if (node != null && node.walkable)
                return candidate;
        }
        Debug.LogWarning("No walkable position found");
        return FlatPosition;
    }

    public void OnPathFailed()
    {
        goatNightState = GoatState.SEARCH;
    }
}