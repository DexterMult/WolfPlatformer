using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsSetting : MonoBehaviour
{
    public GameObject settingPanel;
    public GameObject settingSoundPanel;
    private Scene currentScene;
    private int currentSceneNumber;
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

    public void LoadManeMenu()
    {
        SceneManager.LoadScene("ManeMenu");
    }

    public void RestartLvl()
    {
        SceneManager.LoadScene(currentSceneNumber);
    }

    public void LoadNextLvl()
    {
        int nextLvlNumber = currentSceneNumber + 1;

        if (nextLvlNumber < SceneManager.sceneCountInBuildSettings)
        {
            Debug.Log("Текущая сцена" + currentSceneNumber + "Номер следующей" + nextLvlNumber);
            SceneManager.LoadScene(nextLvlNumber);
        }
        else
        {
            Debug.Log("Сцены не существует");
        }
    }
    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        currentSceneNumber = currentScene.buildIndex;
    }
}
