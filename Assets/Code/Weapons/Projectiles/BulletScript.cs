using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float travelSpeed;

    public int bulletDamage;

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + travelSpeed * transform.right * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().TakeDamage(bulletDamage);
            collision.gameObject.GetComponent<Enemy>().PlayBulletHitSound();
        }

        Destroy(gameObject);
    }
}
