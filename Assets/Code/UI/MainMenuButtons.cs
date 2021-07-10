using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{

    public GameObject MainMenuGroup;
    public GameObject OptionsGroup;
    public GameObject DifficultyGroup;

    public void Difficulty()
    {
        MainMenuGroup.SetActive(false);
        DifficultyGroup.SetActive(true);
    }

    public void Options()
    {
        //MainMenuGroup.SetActive(false);
        //OptionsGroup.SetActive(true);
    }

    public void ReturnToMainMenu()
    {
        DifficultyGroup.SetActive(false);
        OptionsGroup.SetActive(false);
        MainMenuGroup.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void EasyDifficulty(string sceneName)
    {
        UIStatic.Instance.MaxHPValue = 5;
        SceneManager.LoadScene(sceneName);
    }

    public void MediumDifficulty(string sceneName)
    {
        UIStatic.Instance.MaxHPValue = 3;
        SceneManager.LoadScene(sceneName);
    }

    public void HardDifficulty(string sceneName)
    {
        UIStatic.Instance.MaxHPValue = 1;
        SceneManager.LoadScene(sceneName);
    }

}
