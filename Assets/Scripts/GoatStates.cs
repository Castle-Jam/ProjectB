using System;
using UnityEngine;
using UnityEngine.Events;

public class GoatStates : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5;
    [SerializeField] Rigidbody rigidbody;

    private Rigidbody _rigidbody;
    private GoatDayBehaviour goatDayBehaviour;
    private GoatNightBehaviour goatNightBehaviour;
    private Vector3 lastPosition;

    private GameObject interactionRadiusObject;

    public enum GoatState {DAY, NIGHT};
    private GoatState goatState;


    void Start()
    {
        goatDayBehaviour = GetComponent<GoatDayBehaviour>();
        goatNightBehaviour = GetComponent<GoatNightBehaviour>();
        CustomEvent.DayStarted.AddListener(SwitchToDayBehaviour);
        CustomEvent.NightStarted.AddListener(SwitchToNightBehaviour);
        interactionRadiusObject = transform.Find("InteractionRadiusGoat").gameObject;
        _rigidbody = rigidbody;
    }

    void SwitchToDayBehaviour()
    {
        goatState = GoatState.DAY;
        interactionRadiusObject.tag = "Untagged";

    }
    void SwitchToNightBehaviour()
    {
        goatState = GoatState.NIGHT;
        interactionRadiusObject.tag = "Enemy";

    }

    private void OnDestroy()
    {
        CustomEvent.DayStarted.RemoveAllListeners();
        CustomEvent.NightStarted.RemoveAllListeners();
    }

    void Update()
    {
        switch (goatState)
        {
            case GoatState.DAY:
                goatDayBehaviour.Do();
                break;
            case GoatState.NIGHT:
                goatNightBehaviour.Do();
                break;
        }

        // --- Rotation ---
        Vector3 velocity = (transform.position - lastPosition) / Time.deltaTime;
        lastPosition = transform.position;
        velocity.y = 0;

        if (velocity.sqrMagnitude > 0.01f)
        {
            Quaternion targetRot = Quaternion.LookRotation(velocity);

            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.Euler(0, targetRot.eulerAngles.y, 0),
                rotationSpeed * Time.deltaTime
            );
        }
    }
}