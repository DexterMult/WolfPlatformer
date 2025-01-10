using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float clearRetard;
    public Vector2 localSpawnPosition;

    public List<Vector2> localSpawnPoints = new List<Vector2>();
    public string side;
    [SerializeField]
    private float coldownSpawn;

    public const string LEFT = "left";
    public const string RIGHT = "right";
    public const string MID = "mid";

    [SerializeField]
    public GameObject leftPrefab;

    [SerializeField]
    public GameObject midlePrefab;

    [SerializeField]
    public GameObject rightPrefab;

    public void StartSpawn(string side, Vector2 spawnPosition)
    {
        StartCoroutine(SpawnPlatform(side, spawnPosition));
    }

    public IEnumerator SpawnPlatform(string side, Vector2 spawnPosition)
    {
        yield return new WaitForSeconds(coldownSpawn);
        if (side == LEFT)
        {
            GameObject platform = Instantiate(leftPrefab, transform); //спавним префаб внутри актуального объекта
            platform.transform.localPosition = spawnPosition;
        }
        if (side == RIGHT)
        {
            GameObject platform = Instantiate(rightPrefab, transform); //спавним префаб внутри актуального объекта
            platform.transform.localPosition = spawnPosition;
        }
        if (side == MID)
        {
            GameObject platform = Instantiate(midlePrefab, transform); //спавним префаб внутри актуального объекта
            platform.transform.localPosition = spawnPosition;
        }
    }

    public void StartListClear()
    {
        if (localSpawnPoints.Count >= 3)
        StartCoroutine(ClearLocalSpawnPointsList());
    }
    private IEnumerator ClearLocalSpawnPointsList()
    {
        yield return new WaitForSeconds(clearRetard);
        localSpawnPoints.Clear();
    }
    private void Start()
    {
        clearRetard = 3;
        coldownSpawn = 3;
    }
}
