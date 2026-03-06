using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pointer : MonoBehaviour
{
    public RectTransform pointer;
    private float speed = 200f;
    private bool movingRight = true;
    [SerializeField] private InputActionReference interaction;
    private bool active = true;


    void Update()
    {
        if (!active) return;
        float move = speed * Time.deltaTime;
        
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Debug.Log("passiert");
            Interacted();
            
        }

        if (movingRight)
            pointer.anchoredPosition += Vector2.right * move;
        else
            pointer.anchoredPosition += Vector2.left * move;

        if (pointer.anchoredPosition.x > 560)
            movingRight = false;
        if (pointer.anchoredPosition.x < -560)
            movingRight = true;
        
    }
    
    public void Interacted()
    {
        active = false;
        Vector2 pointerPos = transform.position;
        float pointerPosX = pointerPos.x;
        float greenBarLeftOne = 854.17f;
        float greenBarRightOne = 998f;
        float greenBarLeftTwo = 1004f;
        float greenBarRightTwo = 1060f;
        float redBarLeft = 998.9f;
        float redBarRight = 1003.9f;
        Debug.Log(pointerPos);
        if(greenBarLeftOne <= pointerPosX && pointerPosX<= greenBarRightOne)
        {
            Debug.Log("grüner Bereich 1 hehe");
        }
        else if(greenBarLeftTwo <= pointerPosX && pointerPosX<= greenBarRightTwo)
        {
            Debug.Log("grüner Bereich 2 hehe");
        }
        else if(redBarLeft <= pointerPosX && pointerPosX <= redBarRight)
        {
            Debug.Log("roter Bereich");
        }
        else if(pointerPosX < greenBarLeftOne || greenBarRightTwo > pointerPosX)
        {
            Debug.Log("verkackt");
        }
    }
}