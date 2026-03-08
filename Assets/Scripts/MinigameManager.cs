using UnityEngine;
using UnityEngine.InputSystem;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] GameObject Minigame;
    void OnTriggerStay(Collider other)
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && other.gameObject.CompareTag("Player"))
        {
            Minigame.SetActive(true);
        }
        
    }
}
