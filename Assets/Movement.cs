using UnityEngine;

public class SideScrollerCharacterController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float jumpForce = 7.0f;
    public LayerMask groundLayer;

    private Rigidbody rb;
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;
    private Transform groundCheck;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        groundCheck = transform.Find("GroundCheck");

        if (groundCheck == null)
        {
            Debug.LogError("No GroundCheck found. Please add a GroundCheck transform.");
        }
    }

    void Update()
    {
        Move();
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Check if the character is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundLayer, QueryTriggerInteraction.Ignore);
    }

    void Move()
    {
        float move = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(move * moveSpeed, rb.velocity.y, 0f);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}