using UnityEngine;

public class HeroUnparent : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        if (transform.parent != null)
        {
            transform.SetParent(null);
        }
    }
}
