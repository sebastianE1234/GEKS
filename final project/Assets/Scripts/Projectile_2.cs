using UnityEngine;

public class Projectile_2 : MonoBehaviour
{
    public Rigidbody2D projectileRb;
    public float speed;

    public float projectileLife;
    public float projectileCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectileCount = projectileLife;
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;
        if (projectileCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    [System.Obsolete]
    private void FixedUpdate()
    {
        projectileRb.velocity = new Vector2(-speed, projectileRb.velocity.y);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "P1")
        {
            Destroy(collision.gameObject);
        }
        Destroy(gameObject);
    }
}

