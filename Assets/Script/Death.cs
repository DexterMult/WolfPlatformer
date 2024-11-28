using Unity.VisualScripting;
using UnityEngine;

public class Death : MonoBehaviour
{
    GameObject Hero;
    Moove mooveScript;
    private int healch;
    private int HealchChecker()
    {

        healch = mooveScript.healch;

        return healch;
    }
    private void DestroyerHero(GameObject hero)
    {
        if (healch == 0)
        {
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
    }

    // Update is called once per frame
    void Update()
    {
        HealchChecker();
        DestroyerHero(Hero);
    }
}
