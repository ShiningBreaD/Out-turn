using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    public Text title;

    public void Statistics(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
        title.text = "Statistics";
    }

    public void Shop(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
        title.text = "Statistics";
    }

    public void Settings(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }
}
