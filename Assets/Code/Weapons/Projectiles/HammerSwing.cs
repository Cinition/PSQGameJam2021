using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HammerSwing : MonoBehaviour
{
    public int hammerSwing;
    public Vector3 playerVector;
    public float waitDamageTime;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            DelayedDamage(collision.gameObject);
        }
    }

    private async void DelayedDamage(GameObject enemy)
    {
        enemy.GetComponent<Rigidbody2D>().AddForce(playerVector * 15, ForceMode2D.Impulse);

        await Task.Delay(System.TimeSpan.FromSeconds(waitDamageTime));

        enemy.GetComponent<Enemy>().TakeDamage(hammerSwing);
    }
}
