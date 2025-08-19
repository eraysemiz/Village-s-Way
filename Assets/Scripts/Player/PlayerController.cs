using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] float moveSpeed = 2f;
    Vector2 direction;
    public Vector2 lastMoveDir = Vector2.down; // baþlangýç yönü aþaðý

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        direction = new Vector2(h, v).normalized;

        // hareket varsa yönü kaydet
        if (direction != Vector2.zero)
        {
            lastMoveDir = direction;
        }

        // Animator parametreleri
        animator.SetFloat("Horizontal", h);
        animator.SetFloat("Vertical", v);
        animator.SetFloat("Speed", direction.sqrMagnitude);
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.linearVelocity = direction * moveSpeed;
    }
}
