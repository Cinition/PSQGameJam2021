using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveBulletScript : MonoBehaviour
{

    public float travelSpeed;
    public float explosiveRadius;

    public int explosiveDamage;

    private void Awake()
    {
        transform.Rotate(new Vector3(0, 0, 1), -90);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + travelSpeed * transform.up * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(explosiveDamage);
        }

        Destroy(gameObject);
    }
}
