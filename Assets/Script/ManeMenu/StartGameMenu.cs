using UnityEngine;

public class StartGameMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject settingsPanel;
    public GameObject lvlPanel;
    public void ShowMainMenu()
    {
        mainMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        lvlPanel.SetActive(false);
    }
    void Start()
    {
        ShowMainMenu();
    }

}
