using UnityEngine;

public class AtackMushroom : MonoBehaviour
{
    Moove mooveScript;
    DamageManager damageManager;
    GameObject Heroe;
    Transform trans;
    public int mushroomDamage = 1;
    public Vector2 mushroomDamagePosition;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;

        if (collider.name == "Heroe")
        {
            damageManager.damage = mushroomDamage;
            damageManager.damagerPosition = mushroomDamagePosition;

            damageManager.damageTime = Time.time;
            mooveScript.runDisabler = true;
            damageManager.damageSwitcher = true;
        }
    }

    void Start()
    {

        Heroe = GameObject.Find("Heroe");
        if (Heroe != null)
        {
            mooveScript = Heroe.GetComponent<Moove>();
            damageManager = Heroe.GetComponent<DamageManager>();
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
