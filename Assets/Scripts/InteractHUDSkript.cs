using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class InteractHUDSkript : MonoBehaviour
{
    CheeseCounter cc;

    public GameObject eButton;
    public GameObject button;

    private void Start()
    {
        cc = FindAnyObjectByType<CheeseCounter>();

        button.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        int score = cc.GetScore();
        if (other.gameObject.CompareTag("Player"))
        {
            if (score == 3)
            button.SetActive(false);
        }
            else
            {
                button.SetActive(true);
            }

    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            button.SetActive(false);
        }
    }
}
