using UnityEngine;
using System.Collections;
public class FireballCollision : MonoBehaviour
{
    public int damageAmount = 10;  // Amount of damage dealt when hitting the player

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
            
               if (collision.gameObject.CompareTag("player"))
            {
                Health playerHealth = collision.gameObject.GetComponent<Health>();
                Debug.Log("Fireball Collided");
                if (playerHealth != null)

                {
                    Debug.Log("hi");
                    playerHealth.TakeDamage(damageAmount);
                }
                Destroy(gameObject);
            }



        }



    }




