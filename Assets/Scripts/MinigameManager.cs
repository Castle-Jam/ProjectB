using UnityEngine;
using UnityEngine.InputSystem;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] GameObject Minigame;
    private GoatDayBehaviour goatDayBehaviour;

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
            goatDayBehaviour.TriggerMilking();
        }
        
    }
}
