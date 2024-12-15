using UnityEngine;

public class StartActivePanels : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject settingSoundPanel;
    public GameObject EndGamePanel;
    public GameObject LoseGamePanel;

    void Start()
    {
        settingPanel.SetActive(false);
        settingSoundPanel.SetActive(false);
        EndGamePanel.SetActive(false);
        LoseGamePanel.SetActive(false);
    }
}
