using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject Canvas;
    [SerializeField] GameObject creditsCanvas;

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void ShowCredits()
    {
        Canvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }

    public void BackToMenu()
    {
        Canvas.SetActive(true);
        creditsCanvas.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("spiel aus meow");
        Application.Quit();
    }
}