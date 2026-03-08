using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("AudioClips")]
    public AudioClip nightAmbiente;
    public AudioClip dayAmbiente;
    public AudioClip angryGoat;
    public AudioClip cheeseDone;
    public AudioClip cheeseMaking;
    public AudioClip dayStart;


    public void PlaySFX(AudioClip clip)
    {
        musicSource.PlayOneShot(clip);
    }
    public void StopSFX()
    {
        musicSource.Stop();
    }
    // private void Start()
    // {
    //     string state = "night";//schauen ob tag oder nacht
    //     switch (state)
    //     {
    //         case "day":   
    //             musicSource.clip = dayAmbiente;
    //             musicSource.Play();
    //             break;
    //         case "night":
    //             musicSource.clip = nightAmbiente;
    //             break;

    //     }
    // }

}
