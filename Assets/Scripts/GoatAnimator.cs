using UnityEngine;

public class GoatAnimator : MonoBehaviour
{
    private Animator animator;
    private Vector3 lastPosition;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector3 delta = transform.position - lastPosition;
        delta.y = 0;

        bool isMoving = delta.sqrMagnitude > 0.00001f;
        
        
        animator.SetBool("IsWalking", isMoving);
        lastPosition = transform.position;
    }
}