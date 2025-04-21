using UnityEngine;
using System.Collections;


public class Fireballcollision1 : MonoBehaviour
{

    public int damageAmount = 10;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("P2"))
        {
            // Call the method to deal damage to the player
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            Debug.Log("Fireball Collided");
            if (playerHealth != null)

            {
                Debug.Log("hi");
                playerHealth.TakeDamage(damageAmount);
            }

            // Destroy the fireball after impact
            Destroy(gameObject);
        }
    }
}