using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum GunEmotionTypes
    {
        Basic,
        Happy,
        Angry,
        Excited,
        Scared,
        Sad
    }


    public GunEmotionTypes gunType;

    public GameObject gunObject;
    public GameObject gunSpawnPos;

    public GameObject bulletObject;

    public float intervalShootingTime;
    public float intervalShootingTimer = 0.0f;

    bool canFire;

    public AudioSource m_shootSound;

    private void Start()
    {
        intervalShootingTimer = intervalShootingTime;
        canFire = true;
    }

    private void Update()
    {
        UpdateWeapon();
        if (intervalShootingTimer >= intervalShootingTime)
        {
            canFire = true;
        }
        else
        {
            canFire = false;
            intervalShootingTimer += Time.deltaTime;
        }

        if (Input.GetMouseButton(0))
        {
            if (canFire)
            {
                Fire();
                intervalShootingTimer = 0.0f;
            }
        }
    }

    public virtual void Fire()
    {
        Debug.Log("I Fired No Gun");
    }

    public virtual void UpdateWeapon()
    {
        // Used for hammer
    }
}
