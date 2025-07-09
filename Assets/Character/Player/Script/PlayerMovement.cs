using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;
    Vector2 lastMove;

    // Update is called once per frame

    void Start()
    {
        // Awal game: idle ngadep bawah
        animator.SetFloat("lastMoveX", 0f);
        animator.SetFloat("lastMoveY", -1f);
    }

    void Update()
    {
        // Ambil input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement.Normalize();

        // Update lastMove kalau lagi gerak
        if (movement != Vector2.zero)
        {
            lastMove = movement;
        }

        // Kirim data ke Animator
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("lastMoveX", lastMove.x);
        animator.SetFloat("lastMoveY", lastMove.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        // movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
