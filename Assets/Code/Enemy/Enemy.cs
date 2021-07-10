using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject m_player;
    [SerializeField] private GameObject m_visual;

    [HideInInspector] public UnityEvent m_deathEvent = new UnityEvent();

    [Space]

    [Tooltip("The distance from the player the enemy needs to be to trigger death")]
    [SerializeField] private float m_distanceToTriggerDeath = 1.0f;

    [SerializeField] private float m_moveSpeed = 1.0f;
    [SerializeField] private int m_health = 5; 

    [HideInInspector] public bool m_dead = false;
    private bool m_useDefaultDestroy = true;

    [Header("Audio")]
    public AudioSource m_deathSound;

    [Header("Scoring")]
    [SerializeField] private int m_baseScore = 20;

    void Start()
    {
        
    }


    void Update()
    {
        if(!m_dead)
        {
            //Simple movement. Before pathfinding is a thing
            Vector3 vecToPlayer = m_player.transform.position - transform.position;
            Vector3 dirToPlayer = vecToPlayer.normalized;
            transform.position += dirToPlayer * m_moveSpeed * Time.deltaTime;

            if (vecToPlayer.sqrMagnitude <= m_distanceToTriggerDeath)
            {
                OnDeath();
            }

            if(m_health <= 0)
            {
                OnDeath();
            }
        }

        //Destroy object
        if(m_useDefaultDestroy)
        {
            if (m_dead && !m_deathSound.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(int amount)
    {
        m_health -= amount;
    }

    void OnSpawn()
    {

    }

    void OnDeath()
    {
        m_dead = true;
        if(!m_deathSound.isPlaying)
            m_deathSound.Play();

        m_deathEvent.Invoke();

        m_visual.SetActive(false);

        //add to the player's score
    }

    public void SetUseDefaultDeath(bool state)
    {
        m_useDefaultDestroy = state;
    }
}
