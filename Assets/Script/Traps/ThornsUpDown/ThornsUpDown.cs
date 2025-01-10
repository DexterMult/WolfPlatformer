using System.Collections;
using UnityEngine;

public class ThornsUpDown : MonoBehaviour
{
    [SerializeField]
    private float timeStartDuration;
    [SerializeField]
    private float cooldownDrop; //Задержка между падениями    
    [SerializeField]
    private float cooldownDropNext;    
    [SerializeField]
    private float spawnDuration;//задержка между спавнами
    public GameObject prefabToSpawn;
    private GameObject prefabInstantiate;
    private void Drop()
    {
        Rigidbody2D rb  = prefabInstantiate.GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void SpawnPrefab()
    {
        prefabInstantiate = Instantiate(prefabToSpawn, new Vector2(transform.position.x,transform.position.y), prefabToSpawn.transform.rotation); // Спавним префаб на позиции спавнера
    }



    private IEnumerator SetStart(float time)
    {
            yield return new WaitForSeconds(time);
            StartCoroutine(SetDrop(cooldownDrop));
    }

    private IEnumerator SetDrop(float time)
    {
        SpawnPrefab();
        yield return new WaitForSeconds(time);
        Drop();
        cooldownDrop = cooldownDropNext;
        StartCoroutine(SetStart(spawnDuration));
    }

    void Start()
    {
        StartCoroutine(SetStart(timeStartDuration));
    }

}
