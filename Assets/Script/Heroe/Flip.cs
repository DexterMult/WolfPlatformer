using UnityEngine;

public class Flip : MonoBehaviour
{
    public void FlipBody()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
