using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Particles
    [SerializeField] private GameObject jumpDustPrefab;

    //Input
    private PlayerInputHandler input;

    //Ground Check
    public Transform groundCheck;
    public float groundRadius = 0.2f;
    public LayerMask groundLayer;
    private bool isGrounded = false;

    //Move
    public float speed;
    private Rigidbody2D rb;

    //Jump
    public float jumpForce;
    public float coyoteTime = 0.1f;
    public float jumpBufferTime = 0.1f;
    private float coyoteCounter;
    private float jumpBufferCounter;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandler>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);

        if (isGrounded)
        {
            coyoteCounter = coyoteTime;
        }
        else
        {
            coyoteCounter -= Time.deltaTime;
        }

        if (input.JumpPressed)
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
    }

    public void Move(Vector2 direction)
    {
        rb.linearVelocity = new Vector2(direction.x * speed, rb.linearVelocity.y);
    }

    public void Jump()
    {
        if (jumpBufferCounter > 0 && coyoteCounter > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            Instantiate(jumpDustPrefab, transform.position, Quaternion.identity);

            jumpBufferCounter = 0;
            coyoteCounter = 0;
        }
    }

}
