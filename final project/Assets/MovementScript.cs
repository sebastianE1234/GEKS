using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public int extraJumps = 1; // Added for extra jumps

    private Rigidbody2D rb;
    private bool isGrounded;
    private int jumpCount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpCount = extraJumps;
    }

    void Update()
    {
        // Horizontal Movement
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Ground Check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        if (isGrounded)
        {
            jumpCount = extraJumps; // Reset jump count when grounded
        }

        // Jumping
        if (Input.GetKeyDown(KeyCode.UpArrow) && (isGrounded || jumpCount > 0))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumpCount--;
        }
    }
}
