using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 50f;
    [SerializeField] float rotationSpeed = 5f;
    [SerializeField] Transform meshTransform;

    private Rigidbody _rigidbody;
    private Rigidbody playerBody;
    private Vector2 moveInput;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        playerBody = GetComponentInChildren<Rigidbody>();
    }

    public void Movement(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        // --- Movement ---
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        _rigidbody.AddForce(move * speed, ForceMode.Acceleration);
    }

    void Update()
    {
        Vector3 velocity = _rigidbody.linearVelocity;
        velocity.y = 0;

        if (velocity.sqrMagnitude > 0.01f)
        {
            Quaternion targetRot = Quaternion.LookRotation(velocity);

            meshTransform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.Euler(0, targetRot.eulerAngles.y, 0),
                rotationSpeed * Time.deltaTime
            );
        }
    }
}