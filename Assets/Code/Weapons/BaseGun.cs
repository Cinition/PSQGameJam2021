using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseGun : Gun
{

    public override void Fire()
    {
        Instantiate(bullet, transform);
    }

}
