using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{

    public Transform target;

    public float smoothspeed = 0.125f;
    public Vector3 offest;

    void Start()
    {
        
    }


    private void LateUpdate()
    {
        Vector3 desierdposition = target.position + offest;
        Vector3 smoothedposition = Vector3.Lerp(transform.position, desierdposition, smoothspeed);
        transform.position = smoothedposition;

        transform.LookAt(target);
    }
}
