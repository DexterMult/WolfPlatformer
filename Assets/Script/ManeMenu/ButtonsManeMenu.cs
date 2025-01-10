using UnityEngine;

public class ButtonsManeMenu : MonoBehaviour
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

    public void ShowSettings()
    {
        mainMenuPanel.SetActive(false); 
        settingsPanel.SetActive(true);
        lvlPanel.SetActive(false);
    }
    public void ShowLvlPanel()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        lvlPanel.SetActive(true);
    }
}
