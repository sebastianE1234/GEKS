using UnityEngine;
using System.Collections;

public class FireballCollision : MonoBehaviour
{
    public DamagePopup damagePopup;
    public int damageAmount = 20;
    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            // Call the DamagePopup to show the damage when the fireball hits the player
            Vector3 hitPosition = collision.transform.position + Vector3.up * 1.5f; // Slightly above the player

            damagePopup.ShowDamagePopup(hitPosition, damageAmount);

            // Apply damage to the player
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            Debug.Log("Fireball Collided");

            if (playerHealth != null)
            {
               Debug.Log("hit player");
            }
             Destroy(gameObject);

         
            }



        }



    }




