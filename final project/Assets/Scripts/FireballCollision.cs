using UnityEngine;
using System.Collections;

public class Fireballcollision2 : MonoBehaviour
{
    public int damage = 20;

    private void Start()
    {
        // Ignore collisions with other fireballs
        Collider2D myCollider = GetComponent<Collider2D>();
        GameObject[] fireballs = GameObject.FindGameObjectsWithTag("Shard");

        foreach (GameObject fb in fireballs)
        {
            if (fb != gameObject)
            {
                Collider2D otherCollider = fb.GetComponent<Collider2D>();
                if (otherCollider != null)
                {
                    Physics2D.IgnoreCollision(myCollider, otherCollider);
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(collision.gameObject); // Destroy the wall
            Destroy(gameObject);           // Destroy the fireball
        }

        if (collision.gameObject.CompareTag("player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();

            Debug.Log("Fireball Collided");

            if (playerHealth != null)
            {
                Debug.Log("hit enemy");
                // Apply damage here if needed
            }

            Destroy(gameObject);
        }
    }
}








