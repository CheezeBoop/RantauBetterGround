using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static string nextSpawnPoint;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
