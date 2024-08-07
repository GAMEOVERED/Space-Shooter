using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;  // The enemy prefab to be spawned
    public float spawnRate = 2f;    // Time between each spawn
    public float spawnAreaWidth = 10f; // Width of the spawn area
    public Vector3 spawnRotation = new Vector3(0, 0, 0); // Default rotation of the spawned enemy
    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + spawnRate;
    }

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            nextSpawnTime = Time.time + spawnRate;
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnAreaWidth / 2, spawnAreaWidth / 2), // Random x position within the width
            1,
            transform.position.z // Spawn at the z position of the spawner, assuming the spawner is positioned at the desired z value
        );

        Quaternion rotation = Quaternion.Euler(spawnRotation);
        Instantiate(enemyPrefab, spawnPosition, rotation);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(spawnAreaWidth, 1, 1));
    }
}
