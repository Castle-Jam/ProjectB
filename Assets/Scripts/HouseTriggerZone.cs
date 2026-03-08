using UnityEngine;

public class HouseTriggerZone : MonoBehaviour
{
    [SerializeField] private RoofVisibility roof;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
            roof.SetVisible(false);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            roof.SetVisible(true);
    }
}