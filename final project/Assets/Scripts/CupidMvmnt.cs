using UnityEngine;

public class cupidmovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool usesWASD = true;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool facingRight = true;

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
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void Update()
    {
        float moveInput = 0f;

        if (usesWASD)
        {
            if (Input.GetKey(KeyCode.A)) moveInput = -1f;
            if (Input.GetKey(KeyCode.D)) moveInput = 1f;
            if (Input.GetKeyDown(KeyCode.W))
            {
                linearVelocity = new Vector2(linearVelocity.x, jumpForce);
            }
        }

        // Horizontal movement
        linearVelocity = new Vector2(moveInput * moveSpeed, linearVelocity.y);

        // Flip the character
        if (moveInput > 0 && !facingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && facingRight)
        {
            Flip();
        }

        // Animation parameters
        bool isWalking = moveInput != 0;
        bool isJumping = rb.linearVelocity.y > 0.1f;

        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isJumping", isJumping);
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
