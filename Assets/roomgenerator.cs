using UnityEngine;
using System.Collections.Generic;

public class RoomGenerator : MonoBehaviour
{
    public GameObject roomPrefab;
    public GameObject doorPrefab;
    public GameObject enemyPrefab;
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public int width = 2;
    public int height = 6;
    public float roomWidth = 10f;
    public float roomHeight = 10f;
    public int totalEnemies = 10;

    private List<Transform> potentialEnemyPositions = new List<Transform>();

    void Start()
    {
        GenerateRooms();
        PlaceEnemiesRandomly();
        SpawnPlayers();
    }

    void GenerateRooms()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Vector3 roomPosition = new Vector3(x * roomWidth, y * roomHeight, 0);
                GameObject room = Instantiate(roomPrefab, roomPosition, Quaternion.identity);

                PlaceDoorsInRoom(room);
                CollectEnemyPositions(room);
            }
        }
    }

    void PlaceDoorsInRoom(GameObject room)
    {
        foreach (Transform child in room.transform)
        {
            if (child.name.StartsWith("DoorPosition"))
            {
                Instantiate(doorPrefab, child.position, Quaternion.identity, room.transform);
            }
        }
    }

    void CollectEnemyPositions(GameObject room)
    {
        foreach (Transform child in room.transform)
        {
            if (child.name.StartsWith("EnemyPosition"))
            {
                potentialEnemyPositions.Add(child);
            }
        }
    }

    void PlaceEnemiesRandomly()
    {
        for (int i = 0; i < totalEnemies; i++)
        {
            if (potentialEnemyPositions.Count == 0)
                break;

            int index = Random.Range(0, potentialEnemyPositions.Count);
            Transform enemyPos = potentialEnemyPositions[index];
            Instantiate(enemyPrefab, enemyPos.position, Quaternion.identity);
            potentialEnemyPositions.RemoveAt(index);
        }
    }

    void SpawnPlayers()
    {
        if (width * height > 0)
        {
            Vector3 spawnRoomPosition = new Vector3(0, 0, 0);
            Instantiate(player1Prefab, spawnRoomPosition, Quaternion.identity);
            Instantiate(player2Prefab, spawnRoomPosition + new Vector3(1, 0, 0), Quaternion.identity);
        }
    }
}
