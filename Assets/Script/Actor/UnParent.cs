using UnityEngine;

public class UnParent : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        if (transform.parent != null)
        {
            transform.SetParent(null);
        }
    }
}