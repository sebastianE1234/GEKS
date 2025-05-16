using UnityEngine;

public class playermovement3 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool isPlayer = true; // true = Player 1 (WASD), false = Player 2 (Arrows)

    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private bool facingRight = true;

    // Add isDead flag
    public bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (isDead) return; // Prevent ground check if dead

        // Ground check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void Update()
    {
        if (isDead)
        {
            // Stop all movement and animations when dead
            rb.linearVelocity = Vector2.zero;
            animator.SetBool("Is walking", false);
            animator.SetBool("isJumping", false);
            return;
        }

        float moveInput = 0f;

        // Player 1 controls (WASD)
        if (isPlayer)
        {
            if (Input.GetKey(KeyCode.A)) moveInput = -1f;
            if (Input.GetKey(KeyCode.D)) moveInput = 1f;

            // Jump input
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                animator.SetBool("isJumping", true); // Set jumping animation
            }
        }
        // Player 2 controls (Arrow keys)
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow)) moveInput = -1f;
            if (Input.GetKey(KeyCode.RightArrow)) moveInput = 1f;

            // Jump input
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                animator.SetBool("isJumping", true); // Set jumping animation
            }
        }

        // Horizontal movement
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Update animation state
        animator.SetBool("Is walking", Mathf.Abs(moveInput) > 0.1f);

        // Flip character direction
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // Reset jumping animation when landing
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            animator.SetBool("isJumping", false); // Reset jumping animation when on the ground
        }
    }
}
