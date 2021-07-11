using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AngryGun : Gun
{

    public float swingTime;
    float swingTimer;
    public float swingAngle;

    public int meleeDamage;

    // false = rightSide
    // true = leftSide
    public bool side = false;
    public bool swinging = false;

    Vector3 leftSide;
    Vector3 rightSide;

    private void Start()
    {
        bulletObject.SetActive(false);
    }

    public override void UpdateWeapon()
    {
        Vector3 parent = gameObject.transform.parent.rotation.eulerAngles;
        leftSide = new Vector3(0, 0, parent.z + -swingAngle);
        rightSide = new Vector3(0, 0, parent.z + swingAngle);

        if (swingTimer >= swingTime)
        {
            swinging = false;
            side = !side;
            swingTimer = 0.0f;
            bulletObject.SetActive(false);
        }

        if (swinging)
        {
            swingTimer += Time.deltaTime;
            bulletObject.SetActive(true);
        }

        if (side)
        {
            float t;

            if (swingTimer > 0.0f)
            {
                t = swingTimer * (swingTimer * 2 * swingTimer / 2);
            }
            else
            {
                t = 0.0f;
            }

            Quaternion newRot = Quaternion.Euler(Vector3.Lerp(leftSide, rightSide, swingTimer / swingTime));
            gunSpawnPos.transform.rotation = newRot;
        }
        else
        {
            float t;
            if (intervalShootingTimer > 0.0f)
            {
                t = swingTimer * (swingTimer * 2 * swingTimer / 2);
            }
            else
            {
                t = 0.0f;
            }

            Quaternion newRot = Quaternion.Euler(Vector3.Lerp(rightSide, leftSide, swingTimer / swingTime));
            gunSpawnPos.transform.rotation =  newRot;
        }
    }

    public override void Fire()
    {
        swinging = true;
    }
}
