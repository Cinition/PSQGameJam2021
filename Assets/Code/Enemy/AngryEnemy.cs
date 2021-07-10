using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class AngryEnemy : MonoBehaviour
{
    private Enemy m_enemy;
    [SerializeField] private ParticleSystem m_particleSystem;

    [SerializeField] private float m_explosionDelay = 0.5f;
    private float m_explosionCooldown;


    private void Awake()
    {
        m_enemy = GetComponent<Enemy>();
    }

    void Start()
    {
        m_enemy.m_deathEvent.AddListener(OnDeath);

        m_explosionCooldown = m_explosionDelay;
        m_enemy.SetUseDefaultDeath(false);
    }

    void Update()
    {
        if(m_enemy.m_dead)
        {
            //Delayed explosion
            if(m_explosionCooldown <= 0.0f)
            {
                if(!m_particleSystem.gameObject.activeSelf)
                {
                    m_particleSystem.gameObject.SetActive(true);
                    m_particleSystem.Play();
                }

                //Destroy object
                if (!m_enemy.m_deathSound.isPlaying && !m_particleSystem.isPlaying)
                {
                    Destroy(gameObject);
                }
            }
            else
            {
                m_explosionCooldown -= Time.deltaTime;
            }
        }
    }

    void OnDeath()
    {
        //Make big explosion
    }
}
