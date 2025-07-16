using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class TabsSwitch : MonoBehaviour
{
    public int savecurrent = 1;
    public Image[] tabImages;
    public GameObject[] pages;

    void Start()
    {
        ActivateTab(0);
    }

    public void ActivateTab(int tabNo)
    {
        if (tabNo == 1 && savecurrent == 1)
        {
            for (int i = 0; i < pages.Length; i++)
            {
                pages[i].SetActive(false);
                tabImages[i].color = Color.grey;
            }
            pages[savecurrent - tabNo].SetActive(true);
            tabImages[savecurrent - tabNo].color = Color.white;
            savecurrent = 0;
        }
        else
        {
            for (int i = 0; i < pages.Length; i++)
            {
                pages[i].SetActive(false);
                tabImages[i].color = Color.grey;
            }
            pages[tabNo].SetActive(true);
            tabImages[tabNo].color = Color.white;
            savecurrent = tabNo;
        }
    }
}