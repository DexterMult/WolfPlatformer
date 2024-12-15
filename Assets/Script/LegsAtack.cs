using UnityEngine;

public class LegsAtack : MonoBehaviour
{
    Moove heroeMoove;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyTag"))
        {
            GameObject Enemy = collision.gameObject;
            heroeMoove.heroeAtack = true;
            Destroy(Enemy);

        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        heroeMoove = GetComponentInParent<Moove>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
