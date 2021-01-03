using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    public void switchTo(string name)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(name);
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
