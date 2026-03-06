using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pointer : MonoBehaviour
{
    public RectTransform pointer;
    private float speed = 400f;
    private bool movingRight = true;
    [SerializeField] private InputActionReference interaction;
    private bool active = true;
    private int finishedCheese = 0;


    void Update()
    {
        if (!active) return;
        float move = speed * Time.deltaTime;

        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
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
        Vector2 pointerPos = transform.position;
        float pointerPosX = pointerPos.x;
        float greenBarLeftOne = 854.17f;
        float greenBarRightOne = 998f;
        float greenBarLeftTwo = 1004f;
        float greenBarRightTwo = 1060f;
        float redBarLeft = 998.9f;
        float redBarRight = 1003.9f;

        Debug.Log(finishedCheese);
        if (greenBarLeftOne <= pointerPosX && pointerPosX <= greenBarRightOne)
        {
            Debug.Log("grüner Bereich 1 hehe");
            finishedCheese += 20;
            Debug.Log($"grün 1 {finishedCheese}");
        }
        else if (greenBarLeftTwo <= pointerPosX && pointerPosX <= greenBarRightTwo)
        {
            Debug.Log("grüner Bereich 2 hehe");
            finishedCheese += 20;
            Debug.Log($"grün 2 {finishedCheese}");
        }
        else if (redBarLeft <= pointerPosX && pointerPosX <= redBarRight)
        {
            Debug.Log("roter Bereich");
            finishedCheese += 40;
            Debug.Log($"rot {finishedCheese}");
        }
        else if (pointerPosX < greenBarLeftOne || greenBarRightTwo > pointerPosX)
        {
            Debug.Log("verkackt");
        }
        if (finishedCheese == 100)
        {
            active = false;
            Debug.Log("Cheese finished");
        }
    }
}