using UnityEngine;
using UnityEngine.InputSystem;

public class MilkingSound : MonoBehaviour
{

    AudioManager audioManager;

    [SerializeField] GameObject targetUI;

    void Start()
    {
        audioManager = FindFirstObjectByType<AudioManager>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        if (targetUI != null && targetUI.activeInHierarchy)
        {
            Vector2 input = context.ReadValue<Vector2>();

            if (input.x > 0) 
            {
                audioManager.PlaySFX(audioManager.cheeseMaking);
            }

            if (input.x < 0)
            {
                audioManager.PlaySFX(audioManager.cheeseMaking);
            }
        }
    }
}
