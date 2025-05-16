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

    private Animator animator;
    public bool isJumping;

    // ✅ Add this to enable movement disabling
    public bool isDead = false;

    // Custom linearVelocity property
    public Vector2 linearVelocity
    {
        get => rb.linearVelocity;
        set => rb.linearVelocity = value;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (isDead) return; // ✅ Prevent any movement logic

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void Update()
    {
        if (isDead) // ✅ Stop all input if dead
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetBool("Is walking", false);
            animator.SetBool("isJumping", false);
            return;
        }

        float moveInput = 0f;

        if (usesArrows)
        {
            if (Input.GetKey(KeyCode.LeftArrow)) moveInput = -1f;
            if (Input.GetKey(KeyCode.RightArrow)) moveInput = 1f;
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                animator.SetBool("isJumping", true);
            }
        }

        // Horizontal movement
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Animation state
        animator.SetBool("Is walking", Mathf.Abs(moveInput) > 0.1f);

        // Flip character
        if (moveInput > 0 && !facingRight) Flip();
        else if (moveInput < 0 && facingRight) Flip();

        // Update jumping state
        animator.SetBool("isJumping", rb.linearVelocity.y > 0.1f || rb.linearVelocity.y < -0.1f);
    }

    void Jump()
    {
        if (isDead || !isGrounded) return;

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isJumping = true;
        animator.SetBool("isJumping", true);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
