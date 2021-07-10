using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float travelSpeed;

    public int bulletDamage;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + travelSpeed * transform.right * Time.deltaTime;
    }
}
