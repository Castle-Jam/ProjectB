using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class MinigameManager : MonoBehaviour
{
    [SerializeField] GameObject Minigame;
    private GoatDayBehaviour goatDayBehaviour;
    private PlayerMovement playerMovement;
    public CheeseCounter cheeseCounter;
    public MilkCounter milkCounter;
    private bool onCooldown = false;

    void Start()
    {
        goatDayBehaviour = GetComponentInParent<GoatDayBehaviour>(true);

        if (goatDayBehaviour == null)
            Debug.LogError("No GoatDayBehaviour found on " + gameObject.name);
    }

    void OnTriggerStay(Collider other)
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && other.gameObject.CompareTag("Player") && !milkCounter.IsMilkMax())
        {
            playerMovement = other.GetComponent<PlayerMovement>();

            goatDayBehaviour.TriggerMilking(playerMovement);
            playerMovement.SetInteracting(true);
        }
    }

    public void NotifyFinished()
    {
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
