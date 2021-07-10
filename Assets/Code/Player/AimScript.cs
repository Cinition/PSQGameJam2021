using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimScript : MonoBehaviour
{

    public GameObject aimHolder;
    public Camera MainCamera;

    Vector3 mousePosition;
    Vector3 screenPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        screenPosition = MainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z - MainCamera.transform.position.z));

        Vector3 newEuler = new Vector3(0, 0, Mathf.Atan2((screenPosition.y - transform.position.y), (screenPosition.x - transform.position.x)) * Mathf.Rad2Deg);

        if (Mathf.Abs(newEuler.z) > 90)
        {
            gameObject.GetComponent<WeaponSystem>().FlipGun(false);
        }
        else
        {
            gameObject.GetComponent<WeaponSystem>().FlipGun(true);
        }

        Quaternion newRot = Quaternion.Euler(newEuler);
        aimHolder.transform.rotation = newRot;
    }
}
