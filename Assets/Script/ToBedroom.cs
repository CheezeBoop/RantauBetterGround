using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBedroom : MonoBehaviour
{
    public int sceneBuildIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Entered");

        if (other.CompareTag("Player"))
        {
            Debug.Log("Switching Scene to " + sceneBuildIndex);
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }

    private void Update()
    {
        Debug.Log("Script is active");
    }

}
