using UnityEngine;
using UnityEngine.InputSystem;

public class CheeseManagerOriginal : MonoBehaviour
{
    [SerializeField] GameObject CheeseMinigame;
    void OnTriggerStay(Collider other)
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && other.gameObject.CompareTag("Player"))
        {
            CheeseMinigame.SetActive(true);
        }
        
    }
}
