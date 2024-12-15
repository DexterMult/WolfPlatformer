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
            Debug.Log("Сцена не найдена");
        }
        else
            SceneManager.LoadScene("LVL" + currentLVLIndex);
    }
    private bool IsSceneExists(string sceneName)
    {
        // Получаем количество сцен в сборке
        int sceneCount = SceneManager.sceneCountInBuildSettings;

        // Перебираем все сцены в сборке
        for (int i = 0; i < sceneCount; i++)
        {
            // Получаем путь к сцене по индексу
            string scenePath = SceneUtility.GetScenePathByBuildIndex(i);
            // Извлекаем имя сцены из пути
            string sceneNameFromPath = System.IO.Path.GetFileNameWithoutExtension(scenePath);

            // Сравниваем с искомым именем
            if (sceneNameFromPath == sceneName)
            {
                return true; // Сцена найдена
            }
        }
        return false; // Сцена не найдена
    }
}
