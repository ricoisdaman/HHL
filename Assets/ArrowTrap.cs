using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float shootingInterval = 2f; // Time in seconds between each shot
    public float arrowSpeed = 10f;

    private float timer;

    void Start()
    {
        timer = shootingInterval;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            ShootArrow();
            timer = shootingInterval;
        }
    }

    void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, transform.position, transform.rotation);
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.velocity = Vector3.down * arrowSpeed;
    }
}
