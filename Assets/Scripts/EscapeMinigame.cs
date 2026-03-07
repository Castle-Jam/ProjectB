using UnityEngine;
using UnityEngine.InputSystem;

public class EscapeMinigame : MonoBehaviour
{
   

    
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame)
        {
           transform.GetChild(0).gameObject.SetActive(false);
           transform.GetChild(1).gameObject.SetActive(false);

        }
        
    }
}
