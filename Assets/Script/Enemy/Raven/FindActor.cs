using UnityEngine;

public class FindActor : MonoBehaviour
{
    private RunRaven runRaven;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("ActorTag"))
        {
            runRaven.SetActorTarget(collision.transform, true);
            runRaven.SetGroundChecker(collision.gameObject.GetComponent<GroundChecker>());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

    }
    private void Start()
    {
        runRaven = GetComponentInParent<RunRaven>();
    }
}
