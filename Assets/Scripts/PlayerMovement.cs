using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] float rotationSpeed = 5f;

    public Vector2 MoveInput => moveInput;

    enum PlayerState
    {
        IDLE,
        WALKING,
        SPRINTING,
        INTERACTING
    }

    [SerializeField] private PlayerState playerState;

    private Rigidbody _rigidbody;
    private Rigidbody playerBody;
    private Vector2 moveInput;

    // --- Dashing ---
    [FormerlySerializedAs("dashMultiplier")] [SerializeField]
    public float sprintMultiplier = 2f;

    private bool sprintInput;
    [SerializeField] private float sprintCounter;
    [SerializeField] private bool sprintExhausted;


    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
    }

    void Update()
    {
        HandleState();
        switch (playerState)
        {
            default:
            case PlayerState.IDLE:
                if (moveInput.sqrMagnitude < 0.01f) Idle();
                break;
            case PlayerState.WALKING:
                HandleWalking();
                break;
            case PlayerState.SPRINTING:
                HandleSprint();
                break;
            case PlayerState.INTERACTING:
                HandleInteract();
                break;
        }

        if (playerState == PlayerState.SPRINTING)
            sprintCounter++;
        else if (sprintCounter >= 0 && playerState != PlayerState.SPRINTING)
            sprintCounter--;


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
        {
            sprintInput = true;
            HandleState();
        }

        if (context.canceled)
        {
            sprintInput = false;
            HandleState();
        }
    }

    private void HandleState()
    {
        if (!sprintExhausted && sprintCounter > 99) sprintExhausted = true;
        else if (sprintExhausted && sprintCounter < 1) sprintExhausted = false;

        if (playerState == PlayerState.INTERACTING) return;

        if (moveInput.sqrMagnitude > 0.01f)
            playerState = CanSprint() ? PlayerState.SPRINTING : PlayerState.WALKING;
        else
            playerState = PlayerState.IDLE;
    }

    private bool CanSprint()
    {
        return sprintInput && sprintCounter < 100 && !sprintExhausted;
    }

    private void HandleSprint()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        _rigidbody.AddForce(move * speed * sprintMultiplier, ForceMode.Acceleration);
    }

    public void Idle()
    {
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezeAll;
        HandleState();
    }

    public void HandleInteract()
    {
        _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
    }

    public void SetInteracting(bool interacting)
    {
        if (interacting)
        {
            playerState = PlayerState.INTERACTING;
            _rigidbody.linearVelocity = Vector3.zero;
            _rigidbody.constraints = RigidbodyConstraints.FreezePosition;
        }
        else
        {
            _rigidbody.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY;
        }
    }
}