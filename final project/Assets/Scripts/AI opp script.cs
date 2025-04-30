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

        // Flip to face the player
        if (Mathf.Abs(dx) > 0.1f)
        {
            if (dx > 0 && !facingRight)
                Flip();
            else if (dx < 0 && facingRight)
                Flip();
        }

        // Move toward the player
        if (Mathf.Abs(dx) > 0.2f && distance > 1f)
        {
            Vector2 moveDir = new Vector2(dx, 0).normalized;
            rb.linearVelocity = new Vector2(moveDir.x * moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
        }

        // Shoot if within range and cooldown passed
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

        // Flip the scale on X axis
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;

        Debug.Log("Flipped. Now facingRight = " + facingRight);
    }

    void Shoot()
    {
        if (fireballPrefab == null || firePoint == null)
        {
            Debug.LogWarning("Missing fireballPrefab or firePoint reference.");
            return;
        }

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
