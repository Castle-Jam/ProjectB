using UnityEngine;
using UnityEngine.InputSystem;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] GameObject Minigame;
    private GoatDayBehaviour goatDayBehaviour;
    private PlayerMovement playerMovement;

    void Start()
    {
        goatDayBehaviour = GetComponentInParent<GoatDayBehaviour>(true);

        if (goatDayBehaviour == null)
            Debug.LogError("No GoatDayBehaviour found on " + gameObject.name);
    }

    void OnTriggerStay(Collider other)
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && other.gameObject.CompareTag("Player"))
        {
            playerMovement = other.GetComponent<PlayerMovement>();

            goatDayBehaviour.TriggerMilking(playerMovement);
            playerMovement.SetInteracting(true);
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
