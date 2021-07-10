using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : Gun
{

    public float bulletSpeed;

    public override void Fire()
    {
        GameObject bullet = Instantiate(bulletObject, gunSpawnPos.transform.position, gunObject.transform.rotation);
        bullet.GetComponent<BulletScript>().travelSpeed = bulletSpeed;
    }

}
