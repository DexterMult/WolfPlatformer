using UnityEngine;

public class BonusesChecker : MonoBehaviour
{
    public int coin = 0;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BunTag")) 
        {
            coin++;
            Debug.Log("Очки: " + coin);
            Destroy(other.gameObject);
        }
    }
    void Start()
    {
        coin = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
