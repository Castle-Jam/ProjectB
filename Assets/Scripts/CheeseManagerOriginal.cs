using UnityEngine;
using UnityEngine.InputSystem;

public class CheeseManagerOriginal : MonoBehaviour
{
    [SerializeField] GameObject CheeseMinigame;
    private PlayerMovement playerMovement;
    private Pointer pointer;

    void Start()
    {
        pointer = CheeseMinigame.GetComponent<Pointer>();
        if (pointer == null)
            Debug.LogError("No Pointer component found on CheeseMinigame");
    }

    void OnTriggerStay(Collider other)
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && other.gameObject.CompareTag("Player"))
        {
            playerMovement = other.GetComponent<PlayerMovement>();
            playerMovement?.SetInteracting(true);
            pointer?.SetPlayer(playerMovement);
            CheeseMinigame.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerMovement = null;
        }
    }
}