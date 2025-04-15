using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed = 10f;
    public float damage = 25f;

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("P1"))
        {
            Debug.Log("Fireball hit player!");

            PlayerHealth health = collision.gameObject.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}
