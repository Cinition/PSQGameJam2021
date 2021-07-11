using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D m_rb;
    Vector3 m_newPos;

    public float moveSpeed = 1f;
    Vector2 movement;

    private void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_newPos = m_rb.position;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        m_rb.MovePosition(m_rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
