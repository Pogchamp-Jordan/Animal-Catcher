using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenesManager : MonoBehaviour
{
    public string playSceneName = "Play", endSceneName = "End";

    public void StartGame()
    {
        SceneManager.LoadScene(playSceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void GoToEndScreen()
    {
        SceneManager.LoadScene(endSceneName);
    }
}
