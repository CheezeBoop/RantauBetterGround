using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterKerja : MonoBehaviour
{
    public string sceneToLoad = "FoodStall";
    public float detectionRadius = 2f;
    private bool sceneLoaded = false;

    void Update()
    {
        if (sceneLoaded) return;

        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRadius);

        foreach (Collider hit in hits)
        {
            Debug.Log("Terdeteksi: " + hit.gameObject.name); // <-- cek di Console

            if (hit.gameObject.name == "Player") // Pastikan persis sama
            {
                Debug.Log("Player ditemukan. Load scene!");
                sceneLoaded = true;
                SceneManager.LoadScene(sceneToLoad);
            }

            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
