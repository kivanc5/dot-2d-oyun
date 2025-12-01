using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 3f;
    [SerializeField] private Transform player;

    [Header("Jump Settings")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Movement();
        Jump();
    }

    private void Movement()
    {
        float moveX = Input.GetAxisRaw("Horizontal");

        rb.linearVelocity = new Vector2(moveX * moveSpeed, rb.linearVelocityY);
        if (moveX < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if(moveX > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}