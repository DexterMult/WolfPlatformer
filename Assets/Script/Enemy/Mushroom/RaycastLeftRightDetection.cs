using UnityEngine;

public class RaycastLeftRightDetection : MonoBehaviour
{
    Transform EnemyTransform;
    private float raycastDistance;
    [SerializeField] private LayerMask IgnoreRaycast;
    MooveMushroom MooveMushroom;

    private void RaycastLeftRightChecker()
    {
        RaycastHit2D hitLeft = Physics2D.Raycast(EnemyTransform.position, Vector2.left, raycastDistance, ~IgnoreRaycast);
        RaycastHit2D hitRight = Physics2D.Raycast(EnemyTransform.position, Vector2.right, raycastDistance, ~IgnoreRaycast);
        Debug.DrawRay(EnemyTransform.position, Vector2.left * raycastDistance, Color.red);
        Debug.DrawRay(EnemyTransform.position, Vector2.right * raycastDistance, Color.red);
        if (hitLeft.collider != null)
        {
            Debug.Log(hitLeft.collider.name);
            MooveMushroom.rightCollision = false;
            MooveMushroom.leftCollision = true;
        }
        if (hitRight.collider != null)
        {
            Debug.Log(hitRight.collider.name);
            MooveMushroom.leftCollision = false;
            MooveMushroom.rightCollision = true;
        }
    }
    void Start()
    {
        raycastDistance = 0.5f;
        EnemyTransform = GetComponent<Transform>();
        MooveMushroom = GetComponent<MooveMushroom>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastLeftRightChecker();
    }
}
