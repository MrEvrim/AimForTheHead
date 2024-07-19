using UnityEngine;

public class SpawnPoints : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float spawnInterval = 160f;
    public int pointValue = -1;
    public int pointKillValue = 1;

    private EnemySpawnManager spawnManager;

    void Start()
    {
        // Belirli aralıklarla SpawnPrefab fonksiyonunu çağırmak için InvokeRepeating'i kullan
        InvokeRepeating("SpawnPrefab", 0f, spawnInterval);
        spawnManager = GameObject.FindObjectOfType<EnemySpawnManager>();
    }

    void SpawnPrefab()
    {
        // Random bir konum seç
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }

    void OnDisable()
    {
        if (spawnManager != null && spawnManager.IsSpawnPointActive(gameObject))
        {
            spawnManager.AddScore(pointValue);
            spawnManager.KillAddScore(pointKillValue);
        }
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 randomOffset = new Vector3(Random.Range(-5f, 5f), 10f, Random.Range(-5f, 5f));
        // Spawn noktasının konumunu al
        Vector3 spawnPointPosition = transform.position;
        Vector3 spawnPosition = spawnPointPosition + randomOffset;

        return spawnPosition;
    }

}