using UnityEngine;

public class ParentSetter : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ActorTag"))
        {
            collision.transform.SetParent(this.transform);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ActorTag"))
        {
            collision.transform.SetParent(null);
        }
    }
}
