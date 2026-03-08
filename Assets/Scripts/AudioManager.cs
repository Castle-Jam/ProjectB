using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;

    [Header("AudioClips")]
    public AudioClip nightAmbiente;
    public AudioClip dayAmbiente;
    public AudioClip angryGoat;
    public AudioClip cheeseDone;
    public AudioClip cheeseMaking;
    public AudioClip milking;


    public void PlaySFX(AudioClip clip)
    {
        musicSource.PlayOneShot(clip);
    }
    public void StopSFX()
    {
        musicSource.Stop();
    }
 
}
