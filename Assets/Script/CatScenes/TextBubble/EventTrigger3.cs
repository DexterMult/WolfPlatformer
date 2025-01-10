using UnityEngine;

public class EventTrigger3 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ActorTag"))
        {
            DialogHandler.StartDialog3();
        }
    }
}
