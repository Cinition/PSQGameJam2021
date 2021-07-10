using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
  
    public enum GunEmotionTypes
    {
        Happy,
        Angry,
        Excited,
        Scared,
        Sad
    }

    public GunEmotionTypes gunType;

    public GameObject gunObject;

    public GameObject bullet;
    public GameObject explodingBullet;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Fire();
        }
    }

    public virtual void Fire()
    {
        Debug.Log("I Fired No Gun");
    }

}
