using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject obstaclePrefab; // Reference to the obstacle prefab
    public float spawnRate = 2f;      // How often to spawn the obstacles
    public float heightOffset = 1f;   // Vertical range for the spawn position (relative to center)

    private float timer = 0;

    void Update()
    {
        timer += Time.deltaTime;

        // Check if it's time to spawn a new obstacle
        if (timer >= spawnRate)
        {
            SpawnObstacle();
            timer = 0;  // Reset the timer
        }
    }

    void SpawnObstacle()
    {
        // Randomize the Y position of the entire obstacle (within a fixed range)
        float randomY = Random.Range(-heightOffset, heightOffset);
        Vector3 spawnPosition = new Vector3(transform.position.x, randomY, -1f);

        // Spawn the obstacle (pipes with a fixed gap) at the new position
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
