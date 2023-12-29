using UnityEngine;

public class SideScrollerCharacterController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 7.0f;
    public int maxJumps = 2; // Maximum number of jumps
    public LayerMask groundLayer; // LayerMask to determine what is considered as ground

    private Rigidbody rb;
    private bool isGrounded;
    private int jumpCount;
    private float groundCheckRadius = 0.2f;
    private Transform groundCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = transform.Find("GroundCheck");
        jumpCount = 0;

        if (groundCheck == null)
        {
            Debug.LogError("No GroundCheck found. Please add a GroundCheck transform.");
        }
    }

    void Update()
    {
        Move();
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < maxJumps))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer, QueryTriggerInteraction.Ignore);
        if (isGrounded && rb.velocity.y <= 0)
        {
            jumpCount = 0;
        }
    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(move * moveSpeed, rb.velocity.y, 0f);
    }

    void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0, 0);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        jumpCount++;
    }
}
