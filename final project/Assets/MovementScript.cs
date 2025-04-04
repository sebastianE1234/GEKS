using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public int maxExtraJumps = 2; // The number of jumps added when landing

    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = maxExtraJumps; // Start with 2 extra jumps
    }

    void Update()
    {
        // Horizontal Movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Ground Check
        bool wasGrounded = isGrounded;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Add 2 jumps when landing
        if (isGrounded && !wasGrounded)
        {
            jumpCount += maxExtraJumps; // Add 2 extra jumps when landing
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount--;
        }
    }
}