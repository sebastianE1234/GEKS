using UnityEngine;

public class heliosmovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool usesArrows = true; // true = use Arrow Keys, false = use A/D/W

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool facingRight = true;

    // Animator reference
    private Animator animator;

    // Custom linearVelocity property
    public Vector2 linearVelocity
    {
        get => rb.linearVelocity;
        set => rb.linearVelocity = value;
    }

    // isJumping bool to control animation transitions
    public bool isJumping;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // Set "isJumping" to false if grounded
        if (isGrounded && isJumping)
        {
            isJumping = false;
            animator.SetBool("isJumping", false); // Reset "isJumping" animation parameter
        }
    }

    void Update()
    {
        float moveInput = 0f;

        // Handle movement input based on arrow keys or WASD
        if (usesArrows)
        {
            if (Input.GetKey(KeyCode.LeftArrow)) moveInput = -1f;
            if (Input.GetKey(KeyCode.RightArrow)) moveInput = 1f;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }

        // Horizontal movement
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Update animation state
        if (Mathf.Abs(moveInput) > 0.1f)
        {
            animator.SetBool("Is walking", true); // Set walking animation
        }
        else
        {
            animator.SetBool("Is walking", false); // Set idle animation
        }

        // Horizontal movement
        linearVelocity = new Vector2(moveInput * moveSpeed, linearVelocity.y);

        // Flip the character based on movement direction
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        // If the player is in the air and presses Up Arrow, don't let them jump again
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            return; // Don't jump if already in the air
        }

        // Update "isJumping" boolean in the animator
        animator.SetBool("isJumping", isJumping);
    }

    void Jump()
    {
        // Apply jump force
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

        // Set isJumping to true to trigger the jump animation
        isJumping = true;
        animator.SetBool("isJumping", true); // Set "isJumping" animation parameter to true
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

}
