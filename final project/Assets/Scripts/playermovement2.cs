using UnityEngine;

public class playermovement2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool isPlayer = true; // Set this in the Inspector per player

    private Rigidbody2D rb;
    private bool isGrounded;
    public Animator animator;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        // Ground Check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }

    [System.Obsolete]
    void Update()
    {
       
        float horizontal = Input.GetAxisRaw("Horizontal");
        float speed = Mathf.Abs(horizontal);

        animator.SetFloat("Speed", speed);

        Vector3 movement = new Vector3(horizontal, 0f, 0f);
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        float moveInput = 0f;


        if (isPlayer)
        {


            if (Input.GetKey(KeyCode.A)) moveInput = -1f;
            if (Input.GetKey(KeyCode.D)) moveInput = 1f;

            if (Input.GetKeyDown(KeyCode.W) && isGrounded)
            {
                rb.linearVelocity = new Vector2(rb.velocity.x, jumpForce);
            }

        }
        else
        {



            if (Input.GetKey(KeyCode.LeftArrow)) moveInput = 1f;
            if (Input.GetKey(KeyCode.RightArrow)) moveInput = -1f;
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }

        // Horizontal Movement
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput != 0)
        {
            animator.SetFloat("Speed", 1f);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);




    }

}
