using UnityEngine;

public class CheckingTheHeight : MonoBehaviour
{
    private SpriteRenderer heroSpriterenderer;
    private SpriteRenderer platformSpriteRenderer;

    private Vector2 bottomHeroPoint;
    private Vector2 topPlatformPoint;

    private bool isHigher;
    void Start()
    {
        isHigher = false;
        platformSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        heroSpriterenderer = Moove.singleton.GetComponent<SpriteRenderer>();
    }

    private bool SetHigherOrLower()
    {
        bottomHeroPoint = heroSpriterenderer.bounds.min;
        topPlatformPoint = platformSpriteRenderer.bounds.max;
        if (topPlatformPoint.y < bottomHeroPoint.y)
        {
            return true;
        }
        else { return false; }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HeroeTag"))
        {
            isHigher = SetHigherOrLower();
            Moove.singleton.isHigher = isHigher;
            Debug.Log(isHigher);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HeroeTag"))
        {
            isHigher = false;
            Moove.singleton.isHigher = isHigher;
        }
    }

}
