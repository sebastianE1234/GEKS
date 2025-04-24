using UnityEngine;
using System.Collections;


public class Fireballcollision1 : MonoBehaviour
{
    public DamagePopup damagePopup;
    public int damageAmount = 20;

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector3 hitPosition = collision.transform.position + Vector3.up * 1.5f;

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
                Debug.Log("hit enemy");
            }
      

        }

            // Destroy the fireball after impact
            Destroy(gameObject);
        }
    }
