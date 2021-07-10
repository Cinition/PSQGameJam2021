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
        spreadVector.y = Random.Range(minSpreadAngle, maxSpreadAngle);

        Debug.Log(spreadVector.y);

        GameObject bullet = Instantiate(bulletObject, gunSpawnPos.transform.position, gunObject.transform.rotation * Quaternion.Euler(spreadVector));
        bullet.GetComponent<BulletScript>().travelSpeed = bulletTravelSpeed;
    }

}
