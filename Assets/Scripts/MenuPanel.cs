using UnityEngine;

public class MenuPanel : MonoBehaviour
{
    public void Statistics(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }

    public void Shop(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }

    public void Settings(GameObject panel)
    {
        panel.SetActive(!panel.activeSelf);
    }
}
