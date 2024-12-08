using UnityEngine;
using TMPro;
public class EndGameCoins : MonoBehaviour
{
    public TextMeshProUGUI coinsResult;
    private int actualCoins;

    public void CoinsResult()
    {
        BonusesChecker bonuses = FindFirstObjectByType<BonusesChecker>();
        if (bonuses != null)
        {
            actualCoins = bonuses.coinInt;
            coinsResult.text = actualCoins.ToString();
        }
    }
    void Start()
    {
        coinsResult.text = "00";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
