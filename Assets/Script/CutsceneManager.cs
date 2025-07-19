using System.Collections;
using UnityEngine;
using TMPro;

public class CutsceneManager : MonoBehaviour
{
    public GameObject[] sceneImages; // Masukkan GameObject image dari hierarchy
    public TextMeshProUGUI subtitleText;
    [TextArea(3, 10)] public string[] subtitles; // Subtitle untuk masing-masing scene

    public float timePerSlide = 5f;      // Lama setiap slide
    public float typingSpeed = 0.05f;    // Kecepatan efek ketik

    private int currentIndex = 0;

    void Start()
    {
        // Nonaktifkan semua image di awal
        foreach (GameObject image in sceneImages)
        {
            image.SetActive(false);
        }

        StartCoroutine(PlayCutscene());
    }

    IEnumerator PlayCutscene()
    {
        while (currentIndex < sceneImages.Length)
        {
            // Tampilkan image saat ini
            sceneImages[currentIndex].SetActive(true);

            // Tampilkan subtitle dengan efek ketik
            subtitleText.text = "";
            yield return StartCoroutine(TypeSubtitle(subtitles[currentIndex]));

            // Tunggu beberapa detik sebelum lanjut
            yield return new WaitForSeconds(timePerSlide);

            // Sembunyikan image setelah selesai
            sceneImages[currentIndex].SetActive(false);
            currentIndex++;
        }

        // Masuk ke scene selanjutnya
        UnityEngine.SceneManagement.SceneManager.LoadScene("City");
    }

    IEnumerator TypeSubtitle(string sentence)
    {
        subtitleText.text = "";

        foreach (char c in sentence)
        {
            subtitleText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
