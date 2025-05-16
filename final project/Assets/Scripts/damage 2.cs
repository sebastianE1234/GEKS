using UnityEngine;

public class damage2 : MonoBehaviour
{

    public int damage = 20;
    private health2 playerHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "player")
        {
            if (playerHealth == null)
            {
                playerHealth = collision.gameObject.GetComponent<health2>();
            }

            playerHealth.TakeDamage(damage);


        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(collision.gameObject); // Destroy the wall
            Destroy(gameObject);           // Destroy the fireball
        }

    }
}
