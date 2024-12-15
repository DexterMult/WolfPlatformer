using UnityEngine;

public class StarsController : MonoBehaviour
{
    [SerializeField]
    private int normalCoinsResult;
    public int actualCoins;
    [SerializeField]
    private float normalTimeResult;
    private float actualGameTime;
    [SerializeField]
    private int normalHealchResult;
    private int actualHealch;

    private int starsForTime;
    private int starsForCoins;
    private int starsForHealch;

    public int finalStarsResult;

    public void StartStarsCalculation()
    {
        GetActualCoins();
        CoinsResult();
        GetActualTime();
        TimeResult();
        GetActualHealch();
        HealchResult();
        finalStarsResult = starsForCoins + starsForTime + starsForHealch;

    }
    private void GetActualCoins()
    {
        BonusesChecker bonuses = FindFirstObjectByType<BonusesChecker>();
        if (bonuses != null)
        {
            actualCoins = bonuses.coinInt;
        }
    }
    private void CoinsResult()
    {
        if (actualCoins >= normalCoinsResult)
        {
            starsForCoins = 1;
        }
    }
    private void GetActualTime()
    {
        Timer timer = FindFirstObjectByType<Timer>();
        actualGameTime = timer._timer;
    }
    private void TimeResult()
    {
        if (actualGameTime <= normalTimeResult)
        {
            starsForTime = 1;
        }
    }
    private void GetActualHealch()
    {
        Healch healch = FindFirstObjectByType<Healch>();
        if (healch != null)
        {
        actualHealch = healch.HitPoints;
        }
    }
    private void HealchResult()
    {
        if (actualHealch >= normalHealchResult)
        {
            starsForHealch = 1;
        }
    }
    
    void Start()
    {
        starsForCoins = 0;
        starsForTime = 0;
        starsForHealch = 0;
        finalStarsResult = 0;
        normalCoinsResult = 10;
        normalTimeResult = 20f;
        normalHealchResult = 2;
    }

}
