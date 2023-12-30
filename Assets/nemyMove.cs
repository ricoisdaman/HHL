using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float patrolDistance = 5f; // Distance in each direction the enemy patrols
    public float speed = 2f; // Speed of the enemy's movement
    private bool movingRight = true; // Direction of movement
    private float startingX; // Starting position of the enemy

    void Start()
    {
        startingX = transform.position.x; // Set the starting position
    }

    void Update()
    {
        // Move the enemy
        transform.Translate(Vector3.right * speed * Time.deltaTime * (movingRight ? 1 : -1));

        // Check if the enemy has reached the patrol distance
        if (movingRight && transform.position.x >= startingX + patrolDistance)
        {
            Flip();
        }
        else if (!movingRight && transform.position.x <= startingX - patrolDistance)
        {
            Flip();
        }
    }

    void Flip()
    {
        // Change the direction of movement
        movingRight = !movingRight;

        // Flip the enemy's orientation (optional)
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
