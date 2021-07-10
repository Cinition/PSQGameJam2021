using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{

    public List<Image> heartList = new List<Image>();

    public GameObject deathScreen;

    public int currentHP;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = UIStatic.Instance.MaxHPValue;
        UIStatic.Instance.HPValue = currentHP;

        for (int i = 0; i < heartList.Count; i++)
        {
            heartList[i].enabled = false;
            if (i <= currentHP - 1)
            {
                heartList[i].enabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0)
        {
            deathScreen.SetActive(true);
        }
        else
        {
            deathScreen.SetActive(false);
        }

        if (UIStatic.Instance.HPValue < currentHP)
        {
            currentHP = UIStatic.Instance.HPValue;

            for (int i = 0; i < heartList.Count; i++)
            {
                heartList[i].enabled = false;
                if (i <= currentHP - 1)
                {
                    heartList[i].enabled = true;
                }
            }
        }
    }
}
