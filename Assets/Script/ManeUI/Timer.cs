using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float _timer;
    public float _secund;
    public float _minuts;
    public TextMeshProUGUI _secundTMP;
    public TextMeshProUGUI _minutsTMP;
    void Start()
    {
        _timer = 0;
        _secund = 0f;
        _minuts = 0f;
        _secundTMP.text = _secund.ToString();
        _minutsTMP.text = _minuts.ToString();
    }

    private void FirstZeroTimer()
    {
        if (_minuts < 10)
        {
            _minutsTMP.text = "0" + _minuts.ToString();
        }
        else
        {
            _minutsTMP.text = _minuts.ToString();
        }

        if (_secund < 10)
        {
        _secundTMP.text = "0" + _secund.ToString();
        }
        else
        {
            _secundTMP.text = _secund.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;

        _secund = Mathf.FloorToInt(_timer % 60);
        _minuts = Mathf.FloorToInt(_timer / 60);

        FirstZeroTimer();
    }
}
