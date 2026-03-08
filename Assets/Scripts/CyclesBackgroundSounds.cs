using UnityEngine;

public class CyclesBackgroundSounds : MonoBehaviour
{
    AudioManager audioManager;
    [SerializeField] AudioSource musicSource;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        CustomEvent.DayStarted.AddListener(DaySound);
        CustomEvent.NightStarted.AddListener(NightSound);
    }
    void DaySound()
    {
        Debug.Log("Dayy");
        musicSource.clip = audioManager.dayAmbiente;
        musicSource.Play();
    }
    void NightSound()
    {
        Debug.Log("Night");
        musicSource.clip = audioManager.nightAmbiente;
        musicSource.Play();
    }
}
