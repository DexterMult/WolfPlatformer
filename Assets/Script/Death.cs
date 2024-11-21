using UnityEngine;

public class Death : MonoBehaviour
{
    GameObject Hero;
    Moove mooveScript;
    private int healch;
    CameraFollow CameraScript;
    private int HealchChecker()
    {
        healch = mooveScript.healch;
        return healch;
    }
    private void DestroyerHero(GameObject hero)
    {
        if (healch == 0)
        {
            CameraScript.heroeLastPosition = Hero.transform.position;
            CameraScript.heroeDeath = true;
            Destroy(hero);
        }
    }
    void Start()
    {
        Hero = GameObject.Find("Heroe");
        if (Hero != null)
        {
            mooveScript = Hero.GetComponent<Moove>();
        }
        GameObject cam = GameObject.Find("Main Camera");
        CameraScript = cam.GetComponent<CameraFollow>();
    }

    // Update is called once per frame
    void Update()
    {
        HealchChecker();
        DestroyerHero(Hero);
    }
}
