using UnityEngine;
public class OrderInLayer : MonoBehaviour
{
    public int sortingOrder;

    private void OnValidate()
    {
        GetComponent<Renderer>().sortingOrder = sortingOrder;
    }


}
