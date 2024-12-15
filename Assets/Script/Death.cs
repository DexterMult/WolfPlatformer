using Unity.VisualScripting;
using UnityEngine;

public class Death : MonoBehaviour
{
    GameObject Hero;
    public GameObject LoseGamePanel;
    Moove mooveScript;
    private int healch;
    public GameObject SoundListener;
    private Sounds soundSCR;
    private int HealchChecker()
    {

        healch = mooveScript.healch;

        return healch;
    }
    private void DestroyerHero(GameObject hero)
    {
        if (healch == 0)
        {
            soundSCR.PlaySound(soundSCR.sounds[6]);
            GetLoseGamePanel();
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
    private void GetLoseGamePanel()
    {
        LoseGamePanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        soundSCR = SoundListener.GetComponent<Sounds>();
        HealchChecker();
        DestroyerHero(Hero);
    }
}
