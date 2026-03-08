using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;


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
    AudioManager audioManager;

    void Awake()
    {audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        text.text = $"Finished Cheese {finishedCheese}%/100%";
        
    }
    void Update()
    {

        if (!active || pointer == null) return;
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Interacted();
        }
        float move = speed * Time.deltaTime;


        if (movingRight)
            pointer.anchoredPosition += UnityEngine.Vector2.right * move;
        else
            pointer.anchoredPosition += UnityEngine.Vector2.left * move;

        if (pointer.anchoredPosition.x > 560)
            movingRight = false;
        if (pointer.anchoredPosition.x < -560)
            movingRight = true;


    }

    public void Interacted()
    {   audioManager.PlaySFX(audioManager.cheeseMaking);
        UnityEngine.Vector2 pointerPos = movingPointer.transform.position;
        float pointerPosX = pointerPos.x;
        float greenBarLeftOne = 854.17f;
        float greenBarRightOne = 998f;
        float greenBarLeftTwo = 1004f;
        float greenBarRightTwo = 1060f;
        float redBarLeft = 998.9f;
        float redBarRight = 1003.9f;


        if ((greenBarLeftOne <= pointerPosX && pointerPosX <= greenBarRightOne)
        || (greenBarLeftTwo <= pointerPosX && pointerPosX <= greenBarRightTwo))
        {

            finishedCheese += 20;
            text.text = $"Finished Cheese {finishedCheese}%/100%";

        }
        else if (redBarLeft <= pointerPosX && pointerPosX <= redBarRight)
        {

            finishedCheese += 40;
            text.text = $"Finished Cheese {finishedCheese}%/100%";

        }
        else
        {
            audioManager.StopSFX();
            movingPointer.transform.position = new UnityEngine.Vector2(403f, 185f);
            finishedCheese = 0;
            text.text = $"You failed {finishedCheese}%";
            PauseMovement(1);

        }
        if (finishedCheese >= 100)
        {
            audioManager.StopSFX();
            active = false;
            audioManager.PlaySFX(audioManager.cheeseDone);
            Die();
        }
    }
    private void Die()
    {
        finishedCheese = 0;
        active = true;
        Awake();
        gameObject.SetActive(false);
    }
    public void PauseMovement(float durationSeconds)
    {
        if (durationSeconds <= 0f) return;
        StopAllCoroutines();
        StartCoroutine(PauseCoroutine(durationSeconds));
    }

    private IEnumerator PauseCoroutine(float duration)
    {
        active = false;
        yield return new WaitForSeconds(duration);
        active = true;
    }
}