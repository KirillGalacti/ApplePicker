using System.Collections;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject applePrefab;
    public Transform spawnPoint;
    public float spawnRate = 1.5f;

    void Start()
    {
        StartCoroutine(SpawnApples());
    }

    IEnumerator SpawnApples()
    {
        while (true)
        {
            float randomX = Random.Range(-10.0f, 10.0f);
            Vector3 spawnPosition = new Vector3(randomX, spawnPoint.position.y, 0);
            Instantiate(applePrefab, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnRate);
        }
    }
}
