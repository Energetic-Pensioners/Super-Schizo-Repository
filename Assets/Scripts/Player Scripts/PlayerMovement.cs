using UnityEngine;

// Скрипт движения для 2D персонажа.

public class PlayerMovement : MonoBehaviour
{
    [Header("Basic Movement Settings")]
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float playerJumpForce = 10f;

    private bool IsFacingRight = true;

    [Header("Ground Check Settings")]
    // Проверка нахождения на земле с помощью пустого объекта под игроком, который сканирует тег "земли".
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckRadius = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    // Подключение Rigidbody2D обязательно для AddForce прыжка и linearVelocity движения.
    private Rigidbody2D rb;

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    private void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * playerSpeed, rb.linearVelocity.y);

        if (moveInput > 0 && !IsFacingRight)
        {
            Flip();
        }
        else if (moveInput < 0 && IsFacingRight)
        {
            Flip();
        }


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            Debug.Log("Jump");
            rb.AddForce(new Vector2(0f, playerJumpForce), ForceMode2D.Impulse);
        }
    }
}
