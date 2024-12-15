using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LVLChoice : MonoBehaviour
{
    private TextMeshProUGUI lvlNum;
    public int sceneIndex;
    void Start()
    {
        lvlNum = GetComponent<TextMeshProUGUI>();
        Scene currentScene = SceneManager.GetActiveScene();
        sceneIndex = currentScene.buildIndex;
        lvlNum.text = "L" + sceneIndex;
    }

}
