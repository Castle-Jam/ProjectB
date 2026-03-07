using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 50f;
    [SerializeField] float rotationSpeed = 5f;

    enum PlayerState { IDLE, WALKING, SPRINTING, INTERACTING}
    private PlayerState playerState;

    private Rigidbody _rigidbody;
    private Rigidbody playerBody;
    private Vector2 moveInput;
    private bool dashInput;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }


    void FixedUpdate()
    {

    }

    void Update()
    {
        
        switch (playerState)
        {
            case PlayerState.IDLE:
                if (moveInput.sqrMagnitude < 0.01f) Idle();
                break;
            case PlayerState.WALKING:
                HandleWalking();
                break;
            case PlayerState.SPRINTING:
                HandleDash();
                break;
            case PlayerState.INTERACTING:
                break;
        }



        // --- Rotation ---
        Vector3 velocity = _rigidbody.linearVelocity;
        velocity.y = 0;

        if (velocity.sqrMagnitude > 0.01f)
        {
            Quaternion targetRot = Quaternion.LookRotation(velocity);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.Euler(0, targetRot.eulerAngles.y, 0),
                rotationSpeed * Time.deltaTime
            );
        }
    }



    public void Walk(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if (moveInput.sqrMagnitude > 0.01f)
            playerState = PlayerState.WALKING;
        else
            playerState = PlayerState.IDLE;
    }

    public void HandleWalking()
    {
        // --- Movement ---
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        _rigidbody.AddForce(move * speed, ForceMode.Acceleration);
    }
    
    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
            playerState = PlayerState.SPRINTING;

        if (context.canceled)
            playerState = moveInput.sqrMagnitude > 0.01f ? PlayerState.WALKING : PlayerState.IDLE;
    }

    private void HandleDash()
    {
        Debug.Log("Dashing");
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        _rigidbody.AddForce(move * speed * 2f, ForceMode.Acceleration);
    }

    public void Idle()
    {
        //Debug.Log("Idling");
    }
}