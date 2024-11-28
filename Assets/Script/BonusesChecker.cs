using UnityEngine;
using TMPro;

public class BonusesChecker : MonoBehaviour
{
    public int coinInt = 0;
    public TextMeshProUGUI _coinTMP;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BunTag")) 
        {
            coinInt++;
            Destroy(other.gameObject);
            _coinTMP.text = coinInt.ToString();
        }
    }
    void Start()
    {
        coinInt = 0;
        _coinTMP.text = "0";
    }

    // Update is called once per frame
    void Update()
    {

    }
}
