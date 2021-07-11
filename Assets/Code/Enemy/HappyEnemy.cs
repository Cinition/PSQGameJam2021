using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class HappyEnemy : MonoBehaviour
{
    private Enemy m_enemy;
    [SerializeField] private GameObject m_healthPickup;

    private void Awake()
    {
        m_enemy = GetComponent<Enemy>();
    }

    void Start()
    {
        m_enemy.m_deathEvent.AddListener(OnDeath);
    }

    void Update()
    {
        
    }

    void OnDeath()
    {
        if(PickupManager.Instance)
            Instantiate(m_healthPickup, transform.position, transform.rotation, PickupManager.Instance.transform);
        else
            Instantiate(m_healthPickup, transform.position, transform.rotation);
    }
}
