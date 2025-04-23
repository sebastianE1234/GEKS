using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool isPlayer = true; // Set this in the Inspector per player

    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        // Ground Check
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
    }

    void Update()
    {




        float moveInput = 0f;


        if (isPlayer)
        {


            if (Input.GetKey(KeyCode.LeftArrow)) moveInput = -1f;
            if (Input.GetKey(KeyCode.RightArrow)) moveInput = 1f;

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }

        }
        else
        {
            
           

            if (Input.GetKey(KeyCode.A)) moveInput = -1f;
            if (Input.GetKey(KeyCode.D)) moveInput = 1f;
            if (Input.GetKeyDown(KeyCode.W))
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
        }

        // Horizontal Movement
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Jumping





    }
    
}
     