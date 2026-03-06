using UnityEditor.ShaderKeywordFilter;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float sprintMultiplier = 10f;
   [SerializeField] float moveSpeed = 10f;
   [SerializeField] float speed = 10f;

   private CharacterController controller;
   private Vector3 moveInput;


    private float horizontal;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    


    public void Movement(InputAction.CallbackContext context)
    {
        //Debug.Log("We are doing the moving");
        moveInput = context.ReadValue<Vector2>();
        

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        controller.Move(move * speed * Time.deltaTime);
    }


}
