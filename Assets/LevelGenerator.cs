using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    public GameObject enemyPrefab; // Assuming one type of enemy prefab
    public int numberOfPlatforms = 20;
    public int totalNumberOfEnemies = 4; // Total number of enemies in the scene
    public float levelWidth = 3f;
    public float minY = 0.2f;
    public float maxY = 1.5f;

    private GameObject[] spawnedPlatforms;

    void Start()
    {
        spawnedPlatforms = new GameObject[numberOfPlatforms];
        GeneratePlatforms();
        //PlaceEnemiesRandomly();
    }

    void GeneratePlatforms()
    {
        Vector3 spawnPosition = new Vector3();

        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            GameObject platform = Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Length)], spawnPosition, Quaternion.identity);
            spawnedPlatforms[i] = platform;
        }
    }

    void PlaceEnemiesRandomly()
    {
        for (int i = 0; i < totalNumberOfEnemies; i++)
        {
            int platformIndex = Random.Range(0, spawnedPlatforms.Length);
            GameObject platform = spawnedPlatforms[platformIndex];

            Vector3 enemySpawnPosition = platform.transform.position;
            enemySpawnPosition.y += enemyPrefab.transform.localScale.y / 2 + platform.transform.localScale.y / 2;

            Quaternion enemyRotation = Quaternion.Euler(0, 0, 0); // Adjust if necessary
            Instantiate(enemyPrefab, enemySpawnPosition, enemyRotation); // No parent assignment
        }
    }
}
