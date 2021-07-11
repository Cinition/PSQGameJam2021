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

    public void EasyDifficulty()
    {
        UIStatic.Instance.MaxHPValue = 5;
        if (Random.Range(0, 2) == 0)
        {
            SceneManager.LoadScene("Map1");
        }
        else
        {
            SceneManager.LoadScene("Map2");
        }
    }

    public void MediumDifficulty()
    {
        UIStatic.Instance.MaxHPValue = 3;
        if (Random.Range(0,2) == 0)
        {
            SceneManager.LoadScene("Map1");
        }
        else
        {
            SceneManager.LoadScene("Map2");
        }
    }

    public void HardDifficulty()
    {
        UIStatic.Instance.MaxHPValue = 1;
        if (Random.Range(0, 2) == 0)
        {
            SceneManager.LoadScene("Map1");
        }
        else
        {
            SceneManager.LoadScene("Map2");
        }
    }

}
