using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] TextMeshPro coinText;

    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    private int coinCount = 0;

    Vector2 movement;
    Vector2 lastMove;

    public float interactRadius = 1.5f;

    void Start()
    {
        lastMove = new Vector2(0f, -1f);
        animator.SetFloat("lastMoveX", lastMove.x);
        animator.SetFloat("lastMoveY", lastMove.y);

        UpdateCoinUI();
    }

    void Update()
    {
        // Ambil input
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        // Prioritaskan gerakan horizontal terlebih dahulu
        if (moveX != 0)
        {
            moveY = 0; // Hapus gerakan vertikal jika sedang tekan horizontal
        }

        movement = new Vector2(moveX, moveY);

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

        // Deteksi objek bernama EnterFood
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactRadius);
        foreach (Collider2D hit in hits)
        {
            if (hit.gameObject.name == "EnterFood")
            {
                Debug.Log("EnterFood Terdeteksi. Pindah scene!");
                SceneManager.LoadScene("FoodStall");
                break;
            }
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Gunakan CompareTag jika objek npc sudah punya tag "npc", jika tidak bisa pakai name
        if (other.gameObject.name == "npc")
        {
            coinCount++;
            Debug.Log("Koin ditambahkan! Total: " + coinCount);
            UpdateCoinUI();
        }
    }

    private void UpdateCoinUI()
    {
        if (coinText != null)
        {
            coinText.text = "Koin: " + coinCount;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, interactRadius);
    }
}
