using UnityEngine;

public class AIOpponent : MonoBehaviour
{
    public Transform player;
    public GameObject fireballPrefab;
    public Transform firePoint;
    public float fireballSpeed = 10f;
    public float shootCooldown = 2f;
    public float shootRange = 3f;
    public float moveSpeed = 2f;

    private bool facingRight = true;
    private float shootTimer = 0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        if (player != null)
        {
            float dx = player.position.x - transform.position.x;

            // Ensure correct initial facing
            if ((dx < 0 && facingRight) || (dx > 0 && !facingRight))
            {
                Flip();
            }
        }
    }


    void Update()
    {
        if (player == null) return;

        float dx = player.position.x - transform.position.x;
        float distance = Vector2.Distance(transform.position, player.position);

        // Flip only if distance is significant
        if (Mathf.Abs(dx) > 0.1f)
        {
            if (dx > 0 && !facingRight)
                Flip();
            else if (dx < 0 && facingRight)
                Flip();
        }

        // Smooth movement
        if (Mathf.Abs(dx) > 0.2f && distance > 1f)
        {
            float move = Mathf.Sign(dx) * moveSpeed;
            rb.linearVelocity = new Vector2(move, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        // Shoot if close enough
        shootTimer -= Time.deltaTime;
        if (distance <= shootRange && shootTimer <= 0f)
        {
            Shoot();
            shootTimer = shootCooldown;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;

        // Flip the scale on X
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

        // Optional: Debug to see flip is called
        Debug.Log("Flipped. Now facingRight = " + facingRight);
    }

    void Shoot()
    {
        Vector2 direction = facingRight ? Vector2.right : Vector2.left;
        Vector2 spawnPosition = (Vector2)firePoint.position + direction * 0.5f;

        GameObject fireball = Instantiate(fireballPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D fireballRb = fireball.GetComponent<Rigidbody2D>();
        if (fireballRb != null)
        {
            fireballRb.linearVelocity = direction * fireballSpeed;
        }

        Debug.Log("Shot fireball in direction: " + direction);
    }
}
