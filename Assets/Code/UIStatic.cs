using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStatic : MonoBehaviour
{
    // static class for variable holding;
    public static UIStatic Instance { get; private set; }

    // HP
    public int MaxHPValue = 0;
    public int HPValue = 0;

    // Score variables
    public int highScore = 0;
    public int comboMultiplier = 0;

    // Emotion meter count
    public int happyValue = 0;
    public int angryValue = 0;
    public int excitedValue = 0;
    public int scaredValue = 0;
    public int sadValue = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
