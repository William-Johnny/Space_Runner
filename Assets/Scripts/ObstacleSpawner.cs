using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] GameObject obstaclePrefab;
    [SerializeField] float timeBetweenWaves = 1f;
    [SerializeField] float timeToSpawn = 2f;

    void Update () {
        if (Time.time > timeToSpawn) {
            SpawnObstacles();
            timeToSpawn = Time.time + timeBetweenWaves;
        }
    }

    void SpawnObstacles() {
        int randomIndex = Random.Range(0, spawnPoints.Length);

        for (int i = 0; i < spawnPoints.Length; i++) {
            if(randomIndex != i) {
                Instantiate(obstaclePrefab, spawnPoints[i].position, Quaternion.identity);
            }
        }
    }
}
