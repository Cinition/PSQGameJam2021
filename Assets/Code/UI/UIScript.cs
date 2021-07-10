using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScript : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        TestingMeter();
    }

    void TestingMeter()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UIStatic.Instance.happyValue = 100;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UIStatic.Instance.angryValue = 100;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UIStatic.Instance.excitedValue = 100;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UIStatic.Instance.scaredValue = 100;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            UIStatic.Instance.sadValue = 100;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            UIStatic.Instance.HPValue--;
        }
    }
}
