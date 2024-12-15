using UnityEngine;
using TMPro;

public class BonusesChecker : MonoBehaviour
{
    public int coinInt = 0;
    public TextMeshProUGUI _coinTMP;
    public GameObject SoundListener;
    private Sounds soundSCR;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BunTag")) 
        {
            soundSCR.PlaySound(soundSCR.sounds[7]);
            coinInt++;
            Destroy(other.gameObject);
            _coinTMP.text = coinInt.ToString();
        }
    }
    void Start()
    {
        soundSCR = SoundListener.GetComponent<Sounds>();
        coinInt = 0;
        _coinTMP.text = "0";
    }

}
