using UnityEngine;

public class SideScrollerCharacterController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 7.0f;
    public int maxJumps = 2; // Maximum number of jumps
    public LayerMask groundLayer; // LayerMask to determine what is considered as ground

    private Rigidbody rb;
    private int jumpCount;
    private float groundCheckRadius = 0.2f;
    private Transform groundCheck;

    private Collider groundCheckCollider;
    private bool isGrounded;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Transform groundCheckTransform = transform.Find("GroundCheckCollider");

        if (groundCheckTransform != null)
        {
            groundCheckCollider = groundCheckTransform.GetComponent<Collider>();
            if (groundCheckCollider == null)
            {
                Debug.LogError("Collider component not found on GroundCheckCollider GameObject");
            }
        }
        else
        {
            Debug.LogError("GroundCheckCollider child GameObject not found");
        }
    }

    void Update()
    {
        Move();
        GroundCheck();
        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < maxJumps))
        {
            Jump();
        }
    }

    void GroundCheck()
    {
        if (groundCheckCollider != null)
        {
            isGrounded = Physics.CheckBox(groundCheckCollider.bounds.center, groundCheckCollider.bounds.extents, Quaternion.identity, groundLayer, QueryTriggerInteraction.Ignore);
            if (isGrounded && rb.velocity.y <= 0)
            {
                jumpCount = 0;
            }
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
        rb.velocity = new Vector3(rb.velocity.x, 0, 0); // Reset vertical velocity for consistent jumps
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        jumpCount++; // Increment jump count
    }
}
