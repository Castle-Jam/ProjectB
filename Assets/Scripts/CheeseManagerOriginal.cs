using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using Unity.VisualScripting;

public class CheeseManagerOriginal : MonoBehaviour
{
    [SerializeField] GameObject CheeseMinigame;
    private PlayerMovement playerMovement;
    private Pointer pointer;
    private bool onCooldown = false;
    public MilkCounter MilkCounter;
    [SerializeField] public CheeseCounter CheeseCounter;

    void Start()
    {
        pointer = CheeseMinigame.GetComponent<Pointer>();
        if (pointer == null)
            Debug.LogError("No Pointer component found on CheeseMinigame");
    }

    void OnTriggerStay(Collider other)
    {
        int tempCounter = MilkCounter.GetScore();
        if (Keyboard.current.eKey.wasPressedThisFrame && other.gameObject.CompareTag("Player") && !CheeseMinigame.activeSelf && !onCooldown && tempCounter >= 3)
        {
                MilkCounter.RemoveMilkAmmount();
                playerMovement = other.GetComponent<PlayerMovement>();
                playerMovement?.SetInteracting(true);
                pointer?.SetPlayer(playerMovement);
                CheeseMinigame.SetActive(true);
        }
    }

    public void NotifyFinished()
    {
        Debug.Log("NotifyFinished called - CheeseCounter: " + (CheeseCounter != null));
        CheeseCounter.AddCheeseAmount();
        StartCoroutine(Cooldown());
    }

    IEnumerator Cooldown()
    {
        onCooldown = true;
        yield return new WaitForSeconds(2.5f);
        onCooldown = false;
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerMovement = null;
        }
    }
}