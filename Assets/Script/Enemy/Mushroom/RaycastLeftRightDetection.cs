using UnityEngine;

public class RaycastLeftRightDetection : MonoBehaviour
{
    GameObject EnemyMoshroom;
    Transform EnemyTransform;
    private float raycastDistance;
    [SerializeField] private LayerMask IgnoreRaycast;
    MooveMushroom MooveMushroom;
    private void Destroyer()
    {
        Destroy(EnemyMoshroom);
    }
    private void RaycastUpChecker()
    {
        RaycastHit2D[] hitUp = Physics2D.RaycastAll(EnemyTransform.position, Vector2.up, raycastDistance);
        Debug.DrawRay(EnemyTransform.position, Vector2.up * raycastDistance, Color.red);
        foreach (RaycastHit2D hit in hitUp)
        {
            if (hit.collider != null)
            {
                GameObject hitObject = hit.collider.gameObject;
                string hitObjectName = hitObject.name;
                if (hitObjectName == "Heroe")
                {
                    Debug.Log("HeroeUp");
                    Destroyer();
                }
            }
        }
    }
    private void RaycastLeftRightChecker()
    {
        RaycastHit2D[] hitsLeft = Physics2D.RaycastAll(EnemyTransform.position, Vector2.left, raycastDistance);
        RaycastHit2D[] hitsRight = Physics2D.RaycastAll(EnemyTransform.position, Vector2.right, raycastDistance);
        Debug.DrawRay(EnemyTransform.position, Vector2.left * raycastDistance, Color.red);
        Debug.DrawRay(EnemyTransform.position, Vector2.right * raycastDistance, Color.red);

        foreach (RaycastHit2D hit in hitsLeft)
        {
            if (hit.collider != null)
            {
                GameObject hitObject = hit.collider.gameObject;
                string hitObjectName = hitObject.name;
                if (hitObjectName != gameObject.name && hitObjectName != "Confiner2D")
                {
                    MooveMushroom.rightCollision = false;
                    MooveMushroom.leftCollision = true;
                }
            }
        }

        foreach (RaycastHit2D hit in hitsRight)
        {
            if (hit.collider != null)
            {
                GameObject hitObject = hit.collider.gameObject;
                string hitObjectName = hitObject.name;
                if (hitObjectName != gameObject.name && hitObjectName != "Confiner2D")
                {
                    MooveMushroom.rightCollision = true;
                    MooveMushroom.leftCollision = false;
                }
            }
        }

    }
    void Start()
    {
        EnemyMoshroom = gameObject;
        raycastDistance = 0.8f;
        EnemyTransform = GetComponent<Transform>();
        MooveMushroom = GetComponent<MooveMushroom>();
    }

    // Update is called once per frame
    void Update()
    {
        //RaycastUpChecker();
        RaycastLeftRightChecker();
    }
}
