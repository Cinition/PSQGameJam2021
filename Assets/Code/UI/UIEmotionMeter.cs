using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIEmotionMeter : MonoBehaviour
{
    public enum EmotionMeters
    {
        Happy,
        Angry,
        Excited,
        Scared,
        Sad
    }

    public EmotionMeters meterType;

    Image slider;

    int meterValue = 0;

    // Start is called before the first frame update
    void Start()
    {
        slider = gameObject.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("adadw");

        UpdateValue();

        slider.fillAmount = (float)meterValue / 100;
    }

    void UpdateValue()
    {
        switch (meterType)
        {
            case EmotionMeters.Happy:
                meterValue = UIStatic.Instance.happyValue;
                break;
            case EmotionMeters.Angry:
                meterValue = UIStatic.Instance.angryValue;
                break;
            case EmotionMeters.Excited:
                meterValue = UIStatic.Instance.excitedValue;
                break;
            case EmotionMeters.Scared:
                meterValue = UIStatic.Instance.scaredValue;
                break;
            case EmotionMeters.Sad:
                meterValue = UIStatic.Instance.sadValue;
                break;
        }
    }
}
