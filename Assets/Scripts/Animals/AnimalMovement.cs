using UnityEngine;

public class AnimalMovement : MonoBehaviour
{
    public float moveSpeed = 1.5f;
    public float moveTime = 2f;     // hareket s�resi
    public float waitTime = 2f;     // bekleme s�resi

    private float timer;
    private Vector2 moveDirection;
    private Rigidbody2D rb;
    private Animator anim;
    private bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        ChooseNewDirection();
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (isMoving)
        {
            rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.deltaTime);

            if (timer <= 0)
            {
                isMoving = false;
                timer = waitTime;
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero;

            if (timer <= 0)
            {
                ChooseNewDirection();
            }
        }

        // Animator�a parametre g�nder
        anim.SetFloat("MoveX", moveDirection.x);
        anim.SetFloat("MoveY", moveDirection.y);
        anim.SetFloat("Speed", isMoving ? 1 : 0);
    }

    void ChooseNewDirection()
    {
        // 4 y�nl� rastgele hareket se�
        int dir = Random.Range(0, 4);

        switch (dir)
        {
            case 0: moveDirection = Vector2.up; break;
            case 1: moveDirection = Vector2.down; break;
            case 2: moveDirection = Vector2.left; break;
            case 3: moveDirection = Vector2.right; break;
        }

        isMoving = true;
        timer = moveTime;
    }
}
