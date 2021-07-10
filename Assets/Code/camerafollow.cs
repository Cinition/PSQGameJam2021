using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{

    public Transform target;

    public float smoothspeed;
    public Vector3 offset;

    private void Update()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedposition = Vector3.Lerp(transform.position, desiredPosition, smoothspeed);
        transform.position = smoothedposition;
    }
}
