using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class SelectedLVL : MonoBehaviour
{
    public int currentLVLIndex;

    public void SelectLVL(int lvlIndex)
    {
        currentLVLIndex = lvlIndex;
    }
    public void StartGame()
    {
        if (IsSceneExists("LVL" + currentLVLIndex) == false)
        {
            Debug.Log("����� �� �������");
        }
        else
            SceneManager.LoadScene("LVL" + currentLVLIndex);
    }
    private bool IsSceneExists(string sceneName)
    {
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        for (int i = 0; i < sceneCount; i++)
        {
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            string sceneNameFromPath = System.IO.Path.GetFileNameWithoutExtension(scenePath);

            if (sceneNameFromPath == sceneName)
            {
                return true;
            }
        }
        return false;
    }
}
