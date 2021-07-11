using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaredGun : Gun
{

    public float burstWaitTime;
    public int burstCount;
    public float bulletTravelSpeed;

    float lastFrameTime;
    int burstCounter = 0;

    public override void Fire()
    {

        if (burstCounter >= burstCount)
        {
            if ((Time.time - lastFrameTime) < burstWaitTime)
            {
                return;
            }
            else
            {
                burstCounter = 0;
            }
        }

        GameObject bullet = Instantiate(bulletObject, gunSpawnPos.transform.position, gunSpawnPos.transform.rotation);
        bullet.GetComponent<BulletScript>().travelSpeed = bulletTravelSpeed;
        if (m_shootSound)
            m_shootSound.Play();

        burstCounter++;

        if (burstCounter >= burstCount)
        {
            lastFrameTime = Time.time;
        }
    }

}
