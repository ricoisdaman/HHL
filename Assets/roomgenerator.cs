using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class RoomGenerator : MonoBehaviour
{
    public GameObject roomPrefab;
    public GameObject doorPrefab;
    public GameObject enemyPrefab;
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public int roomCount = 12; // Total number of rooms to spawn
    public float roomWidth = 10f; // Physical width of each room
    public float roomHeight = 10f; // Physical height of each room
    public int totalEnemies = 10;

    private HashSet<Vector2> occupiedPositions = new HashSet<Vector2>();
    private List<Transform> potentialEnemyPositions = new List<Transform>();

    void Start()
    {
        GenerateRandomRooms();
        PlaceEnemiesRandomly();
        SpawnPlayers();
    }

    void GenerateRandomRooms()
    {
        occupiedPositions.Clear();
        Vector2 currentPos = Vector2.zero;

        for (int i = 0; i < roomCount; i++)
        {
            Vector3 roomPosition = new Vector3(currentPos.x * roomWidth, currentPos.y * roomHeight, 0);
            GameObject room = Instantiate(roomPrefab, roomPosition, Quaternion.identity);

            occupiedPositions.Add(currentPos);

            // Determine the next room position
            currentPos = GetNextRoomPosition(currentPos);

            PlaceDoorsInRoom(room);
            CollectEnemyPositions(room);
        }
    }

    Vector2 GetNextRoomPosition(Vector2 currentPos)
    {
        List<Vector2> possiblePositions = new List<Vector2>
        {
            currentPos + Vector2.up,    // Above
            currentPos + Vector2.right, // Right
            currentPos + Vector2.down,  // Below
            currentPos + Vector2.left   // Left
        };

        possiblePositions.RemoveAll(pos => occupiedPositions.Contains(pos));
        if (possiblePositions.Count == 0) return currentPos; // No more positions available

        return possiblePositions[Random.Range(0, possiblePositions.Count)];
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
        if (occupiedPositions.Count > 0)
        {
            Vector2 firstRoomPos = occupiedPositions.OrderBy(pos => pos.x).ThenBy(pos => pos.y).First();
            Vector3 spawnRoomPosition = new Vector3(firstRoomPos.x * roomWidth, firstRoomPos.y * roomHeight, 0);
            Instantiate(player1Prefab, spawnRoomPosition, Quaternion.identity);
            Instantiate(player2Prefab, spawnRoomPosition + new Vector3(1, 0, 0), Quaternion.identity);
        }
    }

}
