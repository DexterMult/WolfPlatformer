using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 0, -10);
    public Vector3 heroeLastPosition;
    public bool heroeDeath;

    void Start()
    {
        heroeDeath = false;
    }
    
    void Update()
    {
        if (heroeDeath == false)
        {
            transform.position = player.position + offset;
        }
        else { transform.position = heroeLastPosition + offset; }
    }
}

