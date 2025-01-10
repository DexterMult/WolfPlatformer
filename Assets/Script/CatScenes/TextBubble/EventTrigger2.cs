using UnityEngine;

public class EventTrigger2 : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ActorTag"))
        {
            DialogHandler.StartDialog2();
        }
    }
}
