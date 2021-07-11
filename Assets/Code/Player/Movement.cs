using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D m_rb;
    Vector3 m_newPos;

    public float movespeed = 1f;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_newPos = m_rb.position;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_newPos += new Vector3(0, 1, 0) * movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_newPos += new Vector3(-1, 0, 0) * movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_newPos += new Vector3(0, -1, 0)* movespeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_newPos += new Vector3(1, 0, 0) * movespeed * Time.deltaTime;
        }

        m_rb.MovePosition(m_newPos);
    }
}
