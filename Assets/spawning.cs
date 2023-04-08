using System.Collections;
using UnityEngine;


public class spawning : MonoBehaviour
{
    public GameObject targetPrefab;     // The prefab of the target to spawn
    public float spawnDelay = 5.0f;     // The delay between spawns, in seconds
    public float spawnRadius = 10.0f;   // The maximum radius from the center point where the object can spawn
    public float minY = 0.0f;           // The minimum height at which the object can spawn
    public float maxY = 10.0f;          // The maximum height at which the object can spawn

    private void Start()
    {
        StartCoroutine(SpawnTargets());
    }

    private IEnumerator SpawnTargets()
    {
        while (true)
        {
            // Spawn a new target
            Vector3 spawnPosition = transform.position + new Vector3(
                Random.Range(-spawnRadius, spawnRadius),
                Random.Range(minY, maxY),
                0.0f
            );
            Instantiate(targetPrefab, spawnPosition, Quaternion.identity);

            // Wait for the specified delay before spawning the next target
            yield return new WaitForSeconds(spawnDelay);
        }
    }
}
