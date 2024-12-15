using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class Healch : MonoBehaviour
{
    public int HitPoints;
    public Image HP1;
    public Image HP2;
    public Image HP3;
    [Header("RGBA")]
    [SerializeField] private float R;
    [SerializeField] private float G;
    [SerializeField] private float A;
    [SerializeField] private float B;



    private void HPColorSwitcher(Image hitPoint)
    {
        hitPoint.color = new Color(R, G, B, A);
    }
    private void HealchDestroi()
    {
        if(HitPoints == 3)
        {
            return;
        }
        else if (HitPoints == 2)
        {
            HPColorSwitcher(HP3);
        }
        else if (HitPoints == 1)
        {
            HPColorSwitcher(HP2);
        }
        else
        {
            HPColorSwitcher(HP1);
        }
    }
    void Start()
    {
        HitPoints = 3;
        R = 0.5f;
        G = 0;
        B = 0;
        A = 1;
    }
    void Update()
        {
        HealchDestroi();
        }

    }
