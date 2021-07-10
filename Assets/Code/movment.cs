using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movment : MonoBehaviour
{

    public float movespeed = 1f;

    void Start()
    {
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            this.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * movespeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.position += new Vector3(0, -1, 0) * Time.deltaTime * movespeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.position += new Vector3(1, 0, 0) * Time.deltaTime * movespeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * movespeed;
        }
    }
}
