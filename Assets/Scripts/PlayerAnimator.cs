using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb = GetComponentInParent<Rigidbody>();
    }

    void Update()
    {
        Vector3 velocity = rb.linearVelocity;
        velocity.y = 0; // Y ignorieren (Gravitation)
        
        bool isMoving = velocity.sqrMagnitude > 0.1f;
        animator.SetBool("IsWalking", isMoving);
    }
}