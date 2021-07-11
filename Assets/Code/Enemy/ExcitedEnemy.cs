using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class ExcitedEnemy : MonoBehaviour
{
    [SerializeField] private float m_erraticSpeed = 2f;

    [SerializeField] private float m_changeDirectionTime = 0.5f;
    private float m_currentChangeDirTime;

    private Enemy m_enemy;
    [SerializeField] private Transform m_movedir;


    void Start()
    {
        m_currentChangeDirTime = m_changeDirectionTime;

        m_enemy = gameObject.GetComponent<Enemy>();
    }


    void Update()
    {
        m_movedir.LookAt(transform.position + m_enemy.GetMoveDir());
        if(m_currentChangeDirTime > 0f)
        {
            m_currentChangeDirTime -= Time.deltaTime;
        }
        else
        {
            //Vector3 modifier = new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), 0f) * m_erraticSpeed;
            Vector3 modifier = m_movedir.up * Random.Range(-1f, 1f) * m_erraticSpeed;

            m_enemy.AddMovement(modifier, true);

            m_currentChangeDirTime = m_changeDirectionTime;
        }
    }
}
