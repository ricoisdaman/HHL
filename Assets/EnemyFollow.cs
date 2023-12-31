using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float detectionRadius = 5.0f;
    public float moveSpeed = 2.0f;
    private GameObject[] players;
    private Transform targetPlayer;

    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {
        FindClosestPlayer();
        if (targetPlayer != null)
        {
            FollowPlayer();
        }
    }

    void FindClosestPlayer()
    {
        float closestDistance = detectionRadius;
        targetPlayer = null;

        foreach (var player in players)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
            if (distanceToPlayer < closestDistance)
            {
                closestDistance = distanceToPlayer;
                targetPlayer = player.transform;
            }
        }
    }

    void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPlayer.position, moveSpeed * Time.deltaTime);
    }
}
