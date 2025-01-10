using System.Collections;
using UnityEngine;

public class ArrowSpawner : MonoBehaviour
{
    public GameObject objectToSpawn; // ������ ������� ��� ������
    private Vector2 localSpawnPosition; // ��������� ������� ��� ������
    private float localSpawnOffset;


    private float firstSpawnDelay;
    private float StandardSpawnDelay;


    void SpawnObject()
    {
        // ������� ������ � ��������� ����������� ������������ ��������
        GameObject spawnedObject = Instantiate(objectToSpawn, transform.TransformPoint(localSpawnPosition), transform.rotation);

        spawnedObject.GetComponent<Collider2D>().enabled = false;
        // ������������� ��������� ������� ������
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
