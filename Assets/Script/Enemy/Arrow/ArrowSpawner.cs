using System.Collections;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // Префаб объекта для спавна
    private Vector2 localSpawnPosition; // Локальная позиция для спавна
    private float localSpawnOffset;


    private float firstSpawnDelay;
    private float StandardSpawnDelay;


    void SpawnObject()
    {
        // Спавним объект в локальных координатах относительно родителя
        GameObject spawnedObject = Instantiate(objectToSpawn, transform.TransformPoint(localSpawnPosition), transform.rotation);

        spawnedObject.GetComponent<Collider2D>().enabled = false;
        // Устанавливаем родителем текущий объект
        spawnedObject.transform.SetParent(transform);
    }

    private IEnumerator StartSpawn()
    {
        yield return new WaitForSeconds(firstSpawnDelay);
        SpawnObject();
        firstSpawnDelay = StandardSpawnDelay;
        StartCoroutine(StartSpawn());
    }
    void Start()
    {
        firstSpawnDelay = 1f;
        StandardSpawnDelay = 3f;
        localSpawnOffset = 0.75f;
        localSpawnPosition = new Vector2(-localSpawnOffset, 0);
        StartCoroutine(StartSpawn());
    }
}
