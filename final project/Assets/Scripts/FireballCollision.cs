using UnityEngine;

public class FireballCollision : MonoBehaviour
{
    public int damageAmount = 10;  // Amount of damage dealt when hitting the player

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
            
               if (collision.gameObject.CompareTag("P1"))
            {
                PlayerHealth playerHealth1 = collision.gameObject.GetComponent<PlayerHealth>();
            }

            

        }



    }


}


