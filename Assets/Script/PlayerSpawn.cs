using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    void Start()
    {
        if (!string.IsNullOrEmpty(SpawnManager.nextSpawnPoint))
        {
            GameObject spawnPoint = GameObject.Find(SpawnManager.nextSpawnPoint);
            if (spawnPoint != null)
            {
                transform.position = spawnPoint.transform.position;
            }
        }
    }
}
