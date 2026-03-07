using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

//delay spammer werden auf anfang pos zurück gesetzt
public class Pointer : MonoBehaviour
{
    public RectTransform pointer;
    private float speed = 400f;
    private bool movingRight = true;
    [SerializeField] private InputActionReference interaction;
    [SerializeField] GameObject miniGame;
    [SerializeField] GameObject movingPointer;
    private bool active = true;
    private int finishedCheese = 0;
    public TextMeshProUGUI text;

    void Invoke()
    {
        //mini game create
    }
    void Start()
    {
        text.text = $"Finished Cheese {finishedCheese}%/100%";
    }
    void Update()
    {
        if (pointer != null)
        {
            if (!active) return; 
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                Interacted();
            }
            float move = speed * Time.deltaTime;


            if (movingRight)
                pointer.anchoredPosition += Vector2.right * move;
            else
                pointer.anchoredPosition += Vector2.left * move;

            if (pointer.anchoredPosition.x > 560)
                movingRight = false;
            if (pointer.anchoredPosition.x < -560)
                movingRight = true;
        }

    }

    public void Interacted()
    {
        Vector2 pointerPos = movingPointer.transform.position;
        Debug.Log(pointerPos);
        float pointerPosX = pointerPos.x;
        float greenBarLeftOne = 854.17f;
        float greenBarRightOne = 998f;
        float greenBarLeftTwo = 1004f;
        float greenBarRightTwo = 1060f;
        float redBarLeft = 998.9f;
        float redBarRight = 1003.9f;

        
        if (greenBarLeftOne <= pointerPosX && pointerPosX <= greenBarRightOne)
        {
           
            finishedCheese += 20;
            text.text = $"Finished Cheese {finishedCheese}%/100%";
            
        }
        else if (greenBarLeftTwo <= pointerPosX && pointerPosX <= greenBarRightTwo)
        {
            
            finishedCheese += 20;
            text.text = $"Finished Cheese {finishedCheese}%/100%";
           
        }
        else if (redBarLeft <= pointerPosX && pointerPosX <= redBarRight)
        {
            
            finishedCheese += 40;
            text.text = $"Finished Cheese {finishedCheese}%/100%";
            
        }
        else if (pointerPosX < greenBarLeftOne || greenBarRightTwo > pointerPosX)
        {
            //pointer reset öh idk wie :(
            text.text = $"YOu failed {finishedCheese}%";
            pointerPosX = 403f;
            finishedCheese = 0;
            

        }
        if (finishedCheese == 100)
        {
            active = false;
            Debug.Log("Cheese finished");
            Die();
        }
    }
    private void Die()
    {
        Destroy(miniGame);
    }
}