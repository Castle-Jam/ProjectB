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
        Debug.Log("Path received, success: " + pathSuccess);
        if (pathSuccess && newPath.Length > 0)
        {
            path = newPath;
            targetIndex = 0;
            StopCoroutine("FollowPath");
            StartCoroutine("FollowPath");
        }
        else
        {
            //notify goat the path failed
            GetComponent<GoatDayBehaviour>()?.OnPathFailed();
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
