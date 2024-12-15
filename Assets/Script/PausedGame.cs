using UnityEngine;

public class PausedGame : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0f;

        //AudioListener.pause = true; 
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; 
     
        //AudioListener.pause = false;
    }

}
