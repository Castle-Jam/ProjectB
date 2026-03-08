using System;
using UnityEngine;

public class NightCycleManager : MonoBehaviour
{
    [SerializeField] GameObject directionalLight;
    [SerializeField] GameObject nachtFilter;
    
    void Start()
    {
        CustomEvent.DayStarted.AddListener(SwitchToDayLighting);
        CustomEvent.NightStarted.AddListener(SwitchToNightLighting);
    }
    private void OnDestroy()
    {
        CustomEvent.DayStarted.RemoveAllListeners();
        CustomEvent.NightStarted.RemoveAllListeners();
    }
    void SwitchToDayLighting()
    {
        directionalLight.SetActive(true);
        nachtFilter.SetActive(false);
    }
    void SwitchToNightLighting()
    {
        directionalLight.SetActive(false);
        nachtFilter.SetActive(true);
    }

}
