using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string gameScene;
    public void PlayGame()
    {
        SceneManager.LoadScene(gameScene);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
