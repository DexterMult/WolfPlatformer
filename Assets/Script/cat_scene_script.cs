using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class cat_scene_script : MonoBehaviour
{
    public float speed;
    public Text Text;
    int num = 0;
    public string[] texts;
    void Start()
    {
        StartCoroutine(Read());
    }
    IEnumerator Read()
    {
        for (int i = 0; i < texts.Length; i++)
        {
            Text.text += texts[i];
            yield return new WaitForSeconds(speed);
        }
    }
    public void Skip()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Next()
    {
        if (num < texts.Length - 1)
        {
            StopAllCoroutines();
            num++;
            Text.text = string.Empty;
            StartCoroutine(Read());
        }
        else
        {
            SceneManager.LoadScene("SampleScene");
        }
    }


    void Update()
    {
        
    }
}
