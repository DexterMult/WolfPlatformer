using UnityEngine;

public class SavedSistem : MonoBehaviour
{
    private LVLChoice LVLChoice; // ��� ����� ����������� ������
    private StarsController StarsController; //��� ���� � ���-�� �����
    private BonusesChecker BonusesChecker; // ��� ���� � ������
    private Timer Timer; // ��� ���� � �������
    private int lvlNum;
    private float allTimeResult;
    private float timeMinutsResult;
    private float timeSecundsResult;
    private int coinsResult;
    private int starsResult;

    private void SavedCoins()
    {
        coinsResult = BonusesChecker.coinInt;
        if (coinsResult > PlayerPrefs.GetInt("coinsResult" + lvlNum, 0))
        {
            PlayerPrefs.SetInt("coinsResult" + lvlNum, coinsResult);
        }
    }

    private void SavedTime()
    {
        allTimeResult = Timer._timer;
        timeMinutsResult = Timer._minuts;
        timeSecundsResult = Timer._secund;
        if (allTimeResult < PlayerPrefs.GetFloat("allTimeResult" + lvlNum, 0))
        {
            PlayerPrefs.SetFloat("timeMinutsResult" + lvlNum, timeMinutsResult);
            PlayerPrefs.SetFloat("timeSecundsResult" + lvlNum, timeSecundsResult);
        }
    }

    private void SavedStars()
    {
        starsResult = StarsController.finalStarsResult;
        if (starsResult > PlayerPrefs.GetInt("starsResult" + lvlNum, 0))
        {
            PlayerPrefs.SetInt("starsResult" + lvlNum, starsResult);
        }
    }

    public void SavedAllGame()
    {
        SavedCoins();
        SavedTime();
        SavedStars();
    }


    private void Start()
    {
        BonusesChecker = FindFirstObjectByType<BonusesChecker>();
        LVLChoice = GameObject.FindFirstObjectByType<LVLChoice>();
        lvlNum = LVLChoice.sceneIndex;
        StarsController = GameObject.FindFirstObjectByType<StarsController>();
        Timer = GameObject.FindFirstObjectByType<Timer>();
    }
}
