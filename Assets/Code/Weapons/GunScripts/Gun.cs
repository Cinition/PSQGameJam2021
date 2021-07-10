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
    float intervalShootingTimer = 0.0f;

    bool canFire;

    private void Start()
    {
        intervalShootingTimer = intervalShootingTime;
        canFire = true;
    }

    private void Update()
    {
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

}
