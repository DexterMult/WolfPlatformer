using Unity.VisualScripting;
using UnityEngine;

public class POneWay : MonoBehaviour
{
    [SerializeField]
    private Moove moove;
    public Jump Jump;

    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("HeroeTag"))
        {
            moove.isOnPlatform = true;
            Jump.jumpCounter = 0;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("HeroeTag"))
        {
            moove.isOnPlatform = false;
        }
    }
    void Update()
    {
        
    }
}
