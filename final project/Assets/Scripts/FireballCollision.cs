using UnityEngine;
using System.Collections;


public class FireballCollision : MonoBehaviour
{
    public int damage = 20;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("player"))
        {
            Health playerHealth = collision.gameObject.GetComponent<Health>();

            Debug.Log("Fireball Collided");

            if (playerHealth != null)
            { 
                Debug.Log("hit player");

                playerHealth.ShowDamageText(damage);
            }
            Destroy(gameObject);
        }



    }
}
  



    



