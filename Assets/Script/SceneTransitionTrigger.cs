using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionTrigger : MonoBehaviour
{
    public string targetSceneName;
    public string spawnPointName;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SpawnManager.nextSpawnPoint = spawnPointName;
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
