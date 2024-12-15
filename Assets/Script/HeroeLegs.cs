using UnityEngine;

public class HeroeLegs : MonoBehaviour
{
    public GameObject Heroe;
    public Transform transformHeero;
    public Transform transLegs;
    private void HeeroFinder()
    {

        transLegs.position = new Vector3(transformHeero.position.x, transformHeero.position.y);
    }
    void Start()
    {
        Heroe = GameObject.Find("Heroe");
        transLegs.position = new Vector3(transformHeero.position.x, transformHeero.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        HeeroFinder();
    }
}
