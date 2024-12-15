using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class LVLStatistic : MonoBehaviour
{
    [SerializeField]
    private int lvlNum;
    private TextMeshProUGUI actualCoinsTMP;
    private TextMeshProUGUI actualMinutsTMP;
    private TextMeshProUGUI actualSecundTMP;

    private GameObject maneObj;

    private Image ObjStarsOff1;
    private Image ObjStarsOff2;
    private Image ObjStarsOff3;

    private Image ObjStarsOn1;
    private Image ObjStarsOn2;
    private Image ObjStarsOn3;

    private int lastCoinsInGame;
    private float lastMinutsInGame;
    private float lastSecundsInGame;
    private int lastStarsCountInGame;

    private void GetLastResultInGame()
    {
        lastCoinsInGame = PlayerPrefs.GetInt("coinsResult" + lvlNum, 0);
        lastMinutsInGame = PlayerPrefs.GetFloat("timeMinutsResult" + lvlNum, 0);
        lastSecundsInGame = PlayerPrefs.GetFloat("timeSecundsResult" + lvlNum, 0);
        lastStarsCountInGame = PlayerPrefs.GetInt("starsResult" + lvlNum, 0);
    }

    private void GateTMPObjects()
    {
        TextMeshProUGUI[] TMPObjects = maneObj.GetComponentsInChildren<TextMeshProUGUI>();

        foreach (TextMeshProUGUI TMPObject in TMPObjects)
        {
            if (TMPObject.name == "ScoreCount")
            {
                actualCoinsTMP = TMPObject;
            }
            else if (TMPObject.name == "Minuts")
            {
                actualMinutsTMP = TMPObject;
            }
            else if (TMPObject.name == "Second")
            {
                actualSecundTMP = TMPObject;
            }
        }
    }
    private void GateIMGObjects()
    {
        Image[] IMGObjects = maneObj.GetComponentsInChildren<Image>();
        foreach (Image IMGObject in IMGObjects)
        {
            if (IMGObject.name == "StarsOff1")
            {
                ObjStarsOff1 = IMGObject;
            }
            else if (IMGObject.name == "StarsOff2")
            {
                ObjStarsOff2 = IMGObject;
            }
            else if (IMGObject.name == "StarsOff3")
            {
                ObjStarsOff3 = IMGObject;
            }
            else if (IMGObject.name == "StarsOn1")
            {
                ObjStarsOn1 = IMGObject;
            }
            else if (IMGObject.name == "StarsOn2")
            {
                ObjStarsOn2 = IMGObject;
            }
            else if (IMGObject.name == "StarsOn3")
            {
                ObjStarsOn3 = IMGObject;
            }
        }
    }
    private void InstallTMPValues()
    {
        actualCoinsTMP.text = lastCoinsInGame.ToString();
        actualMinutsTMP.text = lastMinutsInGame.ToString();
        actualSecundTMP.text = lastSecundsInGame.ToString();
    }
    private void SetStarsInManeMenu()
    {
        if (lastStarsCountInGame == 0)
        {
            ObjStarsOff1.gameObject.SetActive(true);
            ObjStarsOff2.gameObject.SetActive(true);
            ObjStarsOff3.gameObject.SetActive(true);
            ObjStarsOn1.gameObject.SetActive(false);
            ObjStarsOn2.gameObject.SetActive(false);
            ObjStarsOn3.gameObject.SetActive(false);
        }
        else if (lastStarsCountInGame == 1)
        {
            ObjStarsOff1.gameObject.SetActive(false);
            ObjStarsOff2.gameObject.SetActive(true);
            ObjStarsOff3.gameObject.SetActive(true);
            ObjStarsOn1.gameObject.SetActive(true);
            ObjStarsOn2.gameObject.SetActive(false);
            ObjStarsOn3.gameObject.SetActive(false);
        }
        else if (lastStarsCountInGame == 2)
        {
            ObjStarsOff1.gameObject.SetActive(false);
            ObjStarsOff2.gameObject.SetActive(false);
            ObjStarsOff3.gameObject.SetActive(true);
            ObjStarsOn1.gameObject.SetActive(true);
            ObjStarsOn2.gameObject.SetActive(true);
            ObjStarsOn3.gameObject.SetActive(false);
        }
        else if (lastStarsCountInGame == 3)
        {
            ObjStarsOff1.gameObject.SetActive(false);
            ObjStarsOff2.gameObject.SetActive(false);
            ObjStarsOff3.gameObject.SetActive(false);
            ObjStarsOn1.gameObject.SetActive(true);
            ObjStarsOn2.gameObject.SetActive(true);
            ObjStarsOn3.gameObject.SetActive(true);
        }
    }


    void Start()
    {
        maneObj = gameObject;
        GetLastResultInGame();
        GateTMPObjects();
        InstallTMPValues();
        GateIMGObjects();
        SetStarsInManeMenu();
    }
}
