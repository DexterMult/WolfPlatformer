using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public bool damagePermission;
    public float reservGhostTime;
    public float damageTime;
    public int damage;
    public GameObject SoundListener;
    private Sounds soundSCR;
    private Healch Healch;
    public int healch;
    public Vector2 damagerPosition;
    private Transform trans;
    private Rigidbody2D rb;
    public float kickForce;
    public bool damageSwitcher;
    public float alpha;
    public float ghostTimer;
    public float ghostTime;
    private SpriteRenderer spriteRenderer;
    private void Damage()
    {
        if (damagePermission == false)
        {
            float Timerok = Time.time - (reservGhostTime + damageTime);
            if (Timerok >= reservGhostTime)
            {
                damagePermission = true;
            }
        }

        if (damage != 0)
        {
            soundSCR.PlaySound(soundSCR.sounds[3]);
            damagePermission = false;
            //Healch.HitPoints = healch - damage;
            healch = healch - damage;
            damage = 0;
            if (damagerPosition.x > trans.position.x)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, 0);
                rb.AddForce(new Vector2(-kickForce, kickForce), ForceMode2D.Impulse);
            }
            else if (damagerPosition.x < trans.position.x)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, 0);
                rb.AddForce(new Vector2(+kickForce, kickForce), ForceMode2D.Impulse);
            }

        }
    }

    private void GhostTimer()
    {
        if (damageSwitcher == true)
        {
            alpha = 0.5f;
            SetColor(new Color(1f, 0f, 0f, alpha));
            ghostTimer = Time.time - damageTime;

            if (reservGhostTime <= ghostTimer)
            {
                SetColor(new Color(1f, 1f, 1f, 1));
                alpha = 1;
                damageSwitcher = false;
                return;
            }
            else if (ghostTimer >= ghostTime)
            {
                Moove.singleton.runDisabler = false;
            }
        }
    }

    public void SetColor(Color color)
    {

        spriteRenderer.color = color; // Установка нового цвета
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        damagePermission = true;
        reservGhostTime = 1f;
        damageTime = 0;
        damage = 0;
        soundSCR = SoundListener.GetComponent<Sounds>();
        Healch = GetComponent<Healch>();
        //runDisabler = Moove.singleton.runDisabler;
        spriteRenderer = GetComponent<SpriteRenderer>();
        healch = 3;
        trans = Moove.singleton.trans;
        rb = Moove.singleton.rb;
        kickForce = 50;
        damageSwitcher = false;
        alpha = 0.7f;
        ghostTime = 0.3f;
    }

    // Update is called once per frame
    void Update()
    {
        Damage();
        GhostTimer();
    }
}
