using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExcitedGun : Gun
{

    public float bulletTravelSpeed;
    public float minSpreadAngle;
    public float maxSpreadAngle;

    public override void Fire()
    {
        Vector3 spreadVector = Vector3.zero;
        spreadVector.z = Random.Range(minSpreadAngle, maxSpreadAngle);

        GameObject bullet = Instantiate(bulletObject, gunSpawnPos.transform.position, gunSpawnPos.transform.rotation * Quaternion.Euler(spreadVector));
        bullet.GetComponent<BulletScript>().travelSpeed = bulletTravelSpeed;
        if (m_shootSound)
            m_shootSound.Play();
    }

}
