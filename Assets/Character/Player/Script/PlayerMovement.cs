using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    public float moveSpeed = 100f;
    private Vector2 input;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        if (CoinManager.Instance != null)
        {
            CoinManager.Instance.UpdateUI();
        }
        else
        {
            Debug.LogError("CoinManager.Instance masih null di PlayerMovement!");
        }
    }

    private void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // Tambah koin manual untuk testing
        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("Tombol K ditekan!");
            if (CoinManager.Instance != null)
            {
                CoinManager.Instance.AddCoins(10000);
                Debug.Log("Tambah 5000 koin dari player");
            }
            else
            {
                Debug.LogError("CoinManager.Instance = null");
            }
        }

         // Deteksi manual jika player menyentuh object "asep"
    Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, 0.5f);
    foreach (Collider2D hit in hits)
    {
        if (hit.name == "Asep")
        {
            Debug.Log("Menyentuh asep, tambahkan koin!");
            if (CoinManager.Instance != null)
            {
                CoinManager.Instance.AddCoins(1000);
                Debug.Log("Koin ditambah 1000!");
            }

            Destroy(hit.gameObject);
            break; // keluar dari loop agar tidak double
        }
    }
    }

    private void FixedUpdate()
    {
        if (input.x != 0) input.y = 0;

        rb.linearVelocity = new Vector2(input.x, input.y).normalized * moveSpeed * Time.fixedDeltaTime;

        if (rb.linearVelocity != Vector2.zero)
        {
            animator.SetFloat("moveX", rb.linearVelocity.x);
            animator.SetFloat("moveY", rb.linearVelocity.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            if (CoinManager.Instance != null)
            {
                CoinManager.Instance.AddCoins(1000); // Ambil 1000 dari koin
            }

            Destroy(collision.gameObject);
        }
    }
}
