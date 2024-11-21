using UnityEngine;

public class AtackMushroom : MonoBehaviour
{
    Moove mooveScript;
    GameObject Heroe;
    Transform trans;
    public int mushroomDamage = 1;
    public Vector2 mushroomDamagePosition;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;

        if (collider.name == "Heroe")
        {
            mooveScript.damage = mushroomDamage;
            mooveScript.damagerPosition = mushroomDamagePosition;

            mooveScript.damageTime = Time.time;
            mooveScript.runDisabler = true;
            mooveScript.damageSwitcher = true;
        }
    }

    void Start()
    {

        Heroe = GameObject.Find("Heroe");
        if (Heroe != null)
        {
            mooveScript = Heroe.GetComponent<Moove>();
        }
        trans = GetComponent<Transform>();
        mushroomDamage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        mushroomDamagePosition = trans.position;

    }
}
