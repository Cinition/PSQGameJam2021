using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryExplosion : MonoBehaviour
{
    [SerializeField] private int m_damage = 1;


    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            //Do damage to player
            Debug.Log("damage player with angry explosion");
        }
    }
}
