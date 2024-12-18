using UnityEngine;

public class thorns : MonoBehaviour
{
    Moove mooveScript;
    DamageManager damageManager;
    GameObject Heroe;
    Transform trans;
    public float raycastDistance;
    public int thornsDamage;
    public Vector2 thornsDamagePosition;



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;

        if (collider.name == "Legs" && damageManager.damagePermission == true)
        {
            damageManager.damage = thornsDamage;
            damageManager.damagerPosition = thornsDamagePosition;

            damageManager.damageTime = Time.time;
            mooveScript.runDisabler = true;
            damageManager.damageSwitcher = true;

        }
    }
     private void RaycastUpChecker()
    {
        RaycastHit2D[] hitsLeft = Physics2D.RaycastAll(trans.position, Vector2.up, raycastDistance);
        Debug.DrawRay(trans.position, Vector2.up * raycastDistance, Color.red);
        foreach (RaycastHit2D hit in hitsLeft)
        {
            if (hit.collider.name == "Legs" && damageManager.damagePermission == true)
            {
                damageManager.damage = thornsDamage;
                damageManager.damagerPosition = thornsDamagePosition;

                damageManager.damageTime = Time.time;
                mooveScript.runDisabler = true;
                damageManager.damageSwitcher = true;

            }
        }
    }

    void Start()
    {
        raycastDistance = 0.35f;
        Heroe = GameObject.Find("Heroe");
        if (Heroe != null)
        {
            mooveScript = Heroe.GetComponent<Moove>();
            damageManager = Heroe.GetComponent<DamageManager>();
        }
        trans = GetComponent<Transform>();
        thornsDamage = 1;
        thornsDamagePosition = trans.position;
    }

    void Update()
    {
        RaycastUpChecker();
    }
}
