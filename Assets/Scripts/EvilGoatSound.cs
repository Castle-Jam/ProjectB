using System.Collections;
using UnityEngine;

public class EvilGoatSound : MonoBehaviour
{
    AudioManager audioManager;
    [SerializeField] AudioSource musicSource;

    // [SerializeField] float minTime = 0f;
    // [SerializeField] float maxTime = 1f;
    
    void Start()
    {   musicSource.Stop();
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
        CustomEvent.NightStarted.AddListener(Goat);
    }

    void Goat()
    {musicSource.PlayOneShot(audioManager.angryGoat);
        // StartCoroutine(GoatSoundRandomTime());
    }
    // IEnumerator GoatSoundRandomTime()
    // {
            // float waitTime = Random.Range(minTime, maxTime);
            // yield return new WaitForSeconds(waitTime);

            
        
        
    //}
}
