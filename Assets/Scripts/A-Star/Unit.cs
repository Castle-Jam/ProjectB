using System.Collections;
using UnityEngine;

public class Unit : MonoBehaviour
{
    [SerializeField] public Transform target;
    [SerializeField] float speed = 0.05f;
    Vector3[] path;
    int targetIndex;

    public Vector3 targetPos;

    void Start()
    {
        //PathRequestManager.RequestPath(transform.position, target.position, this.OnPathFound);
    }

    public void OnPathFound(Vector3[] newPath, bool pathSuccess)
    {
        if (pathSuccess)
        {
            path = newPath;
            targetIndex = 0;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
    }

    IEnumerator FollowPath()
    {
        Vector3 currentWaypoint = path[0];
        while (true)
        {
            if (transform.position == currentWaypoint)
            {
                targetIndex ++;
                if (targetIndex >= path.Length)
                {
                    yield break;
                }
                currentWaypoint =  path[targetIndex];
            }
            transform.position = Vector3.MoveTowards(transform.position, currentWaypoint, speed);
            yield return null;
        }
    }
}
