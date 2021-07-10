using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyGun : Gun
{

    public float bulletTravelSpeed;

    public float minSpreadAngle;
    public float maxSpreadAngle;

    public float spreadInAngle;
    public int pelletCount;

    public List<Vector3> pelletEulers = new List<Vector3>();

    private void Start()
    {

        float lastHalfed = spreadInAngle * (pelletCount - 1) * 0.5f;

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
            Vector3 spreadVector = pelletEulers[i];
            spreadVector.z += Random.Range(minSpreadAngle, maxSpreadAngle);

            GameObject bullet = Instantiate(bulletObject, gunSpawnPos.transform.position, gunSpawnPos.transform.rotation * Quaternion.Euler(spreadVector));
            bullet.GetComponent<ExplosiveBulletScript>().travelSpeed = bulletTravelSpeed;
        }

    }

}
