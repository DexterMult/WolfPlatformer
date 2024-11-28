using UnityEngine;

public class SettingUI : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject settingSoundPanel;
    public void ShowGame()
    {
        settingPanel.SetActive(false);
        settingSoundPanel.SetActive(false);
    }
    public void ShowSetting()
    {
        settingPanel.SetActive(true);
        settingSoundPanel.SetActive(false);
    }    

    public void ShowSettingsSoundPanel()
    {
        settingPanel.SetActive(false);
        settingSoundPanel.SetActive(true);
    }

}
