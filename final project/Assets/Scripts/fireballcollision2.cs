using UnityEngine;
using System.Collections;


public class Fireballcollision1 : MonoBehaviour
{

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Call the method to deal damage to the player
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            Debug.Log("Fireball Collided");
            if (playerHealth != null)

            {
                Debug.Log("hit enemy");
                
            }

            // Destroy the fireball after impact
            Destroy(gameObject);
        }
    }
}