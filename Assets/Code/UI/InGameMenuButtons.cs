using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenuButtons : MonoBehaviour
{

    public void Retry(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
