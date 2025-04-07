using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool isPlayerOne = true; // Set this in the Inspector per player

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
        Debug.Log("grounded? " + isGrounded);
    }

    void Update()
    {


        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp(viewPos.x, 0.05f, 0.95f); // Adjust these values as needed
        transform.position = Camera.main.ViewportToWorldPoint(viewPos);

        float moveInput = 0f;
      

        if (isPlayerOne)
        {
            if (Input.GetKey(KeyCode.LeftArrow)) moveInput = -1f;
            if (Input.GetKey(KeyCode.RightArrow)) moveInput = 1f;



        }
        else
        {
            if (Input.GetKey(KeyCode.A)) moveInput = -1f;
            if (Input.GetKey(KeyCode.D)) moveInput = 1f;
        }

        // Horizontal Movement
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);

        // Jumping
    }



}

    