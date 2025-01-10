using UnityEngine;
using System;
public class EventTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("ActorTag"))
    {
        DialogHandler.StartDialog1();
    }
    }
}
