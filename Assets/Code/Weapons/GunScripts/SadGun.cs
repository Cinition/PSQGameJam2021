using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadGun : Gun
{

    public float spreadInAngle;
    public int pelletCount;
    public float pelletSpeed;

    List<Vector3> pelletEulers = new List<Vector3>();

    private void Start()
    {

        float lastHalfed = (spreadInAngle * (pelletCount - 1)) * 0.5f;

        for (int i = 0; i < pelletCount; i++)
        {
            Vector3 newPelletAngle = new Vector3(0, 0,(spreadInAngle * i) - lastHalfed);
            pelletEulers.Add(newPelletAngle);
        }
    }

    public override void Fire()
    {

        for (int i = 0; i < pelletCount; i++)
        {
            GameObject bullet = Instantiate(bulletObject, gunSpawnPos.transform.position, gunSpawnPos.transform.rotation * Quaternion.Euler(pelletEulers[i]));
            bullet.GetComponent<BulletScript>().travelSpeed = pelletSpeed;
        }

    }

}
