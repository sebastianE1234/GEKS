using UnityEngine;

public class AIMovement : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float flipThreshold = 0.2f; // Small dead zone to prevent jitter flipping

    private bool facingRight = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (player == null) return;

        float dx = player.position.x - transform.position.x;

        // Flip to face player only if outside the dead zone
        if (Mathf.Abs(dx) > flipThreshold)
        {
            if ((dx > 0 && !facingRight) || (dx < 0 && facingRight))
                Flip();
        }

        // Move toward player, avoiding small zero-velocity issues
        if (Mathf.Abs(dx) > flipThreshold)
        {
            float moveDir = Mathf.Sign(dx);
            rb.linearVelocity = new Vector2(moveDir * moveSpeed, rb.linearVelocity.y); // Corrected: using rb.velocity
        }
        else
        {
            rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);  // Stop movement when within threshold
        }

        // Apply a constant force for smoother movement
        if (Mathf.Abs(dx) > flipThreshold)
        {
            rb.AddForce(new Vector2(Mathf.Sign(dx) * moveSpeed, 0), ForceMode2D.Force);
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    public bool IsFacingRight()
    {
        return facingRight;
    }
}
