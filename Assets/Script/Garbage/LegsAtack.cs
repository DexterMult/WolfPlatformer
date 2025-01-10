using UnityEngine;

public class LegsAtack : MonoBehaviour
{
    public BounceOffEnemy BounceOffEnemy;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyTag"))
        {
            GameObject Enemy = collision.gameObject;
            BounceOffEnemy.heroeAtack = true;
            Destroy(Enemy);

        }
    }
}