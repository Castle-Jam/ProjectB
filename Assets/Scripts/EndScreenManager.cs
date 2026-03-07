using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenManager : MonoBehaviour
{
    public void RestartLevel()
    {
        SceneManager.LoadScene("Level");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}