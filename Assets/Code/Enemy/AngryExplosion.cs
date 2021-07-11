using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryExplosion : MonoBehaviour
{
    [SerializeField] private int m_damage = 1;

    private bool m_done = false;

    private AudioSource m_explosionSound;

    private void Start()
    {
        m_explosionSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player") && !m_done)
        {
            //Do damage to player

            if (!m_explosionSound.isPlaying)
                m_explosionSound.Play();
            //Debug.Log("damage player with angry explosion");
            UIStatic.Instance.HPValue -= m_damage;
            m_done = true;
        }
    }
}
