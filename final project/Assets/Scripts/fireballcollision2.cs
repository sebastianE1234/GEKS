using UnityEngine;
using System.Collections;


public class Fireballcollision1 : MonoBehaviour
{
    public int damage = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();

            Debug.Log("Fireball Collided");

            if (playerHealth != null)
            {
                Debug.Log("hit enemy");
            }
            Destroy(gameObject);
        }
    }
}