using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHighscore : MonoBehaviour
{

    Text textField;

    // Start is called before the first frame update
    void Start()
    {
        textField = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textField.text = UIStatic.Instance.highScore.ToString();
    }
}
