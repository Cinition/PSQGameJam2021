using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private AudioSource m_pickupAudio;

    [SerializeField] private GameObject m_visual;

    private bool m_pickedUp = false;

    void Start()
    {
        
    }


    void Update()
    {
        if(m_pickedUp)
        {
            if(!m_pickupAudio.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            //todo: heal the player

            if (!m_pickupAudio.isPlaying)
                m_pickupAudio.Play();
            m_pickedUp = true;

            m_visual.SetActive(false);

            //todo: particle effect
        }
    }
}
