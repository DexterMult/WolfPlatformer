using UnityEngine;

public class thorns : MonoBehaviour
{
    Moove mooveScript;
    GameObject Heroe;
    Transform trans;
    public int thornsDamage;
    public Vector2 thornsDamagePosition;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("HeroeTag"))
        {
            Debug.Log("rhorns");
            mooveScript.damage = thornsDamage;
            mooveScript.damagerPosition = thornsDamagePosition;

            mooveScript.damageTime = Time.time;
            //mooveScript.runDisabler = true;
        }
    }

    void Start()
    {

        GameObject Heroe = GameObject.Find("Heroe");
        if (Heroe != null)
        {
            mooveScript = Heroe.GetComponent<Moove>();
        }
        trans = GetComponent<Transform>();
        thornsDamage = 1;
        thornsDamagePosition = transform.position;
    }

    void Update()
    {
        Debug.Log(mooveScript.names);
    }
}
