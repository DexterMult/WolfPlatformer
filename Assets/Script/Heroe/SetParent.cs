using UnityEngine;

public class SetParent : MonoBehaviour
{
    private void SetParrent()
    {
        if (transform.parent == null)
        {
            transform.SetParent(Moove.singleton.transform);
        }
    }
    private void Update()
    {
        SetParrent();
    }
}
