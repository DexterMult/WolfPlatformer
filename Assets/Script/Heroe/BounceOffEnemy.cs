using UnityEngine;

public class BounceOffEnemy : MonoBehaviour
{
    public float atackJumpForce;
    public bool heroeAtack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        heroeAtack = false;
        atackJumpForce = 50f;
    }

    private void BounceUp()
    {
        if (heroeAtack == true)
        {
            Moove.singleton.rb.linearVelocity = new Vector2(Moove.singleton.rb.linearVelocityX, 0);
            Moove.singleton.rb.AddForce(new Vector2(Moove.singleton.trans.position.x, atackJumpForce), ForceMode2D.Impulse);
            heroeAtack = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        BounceUp();
    }
}
