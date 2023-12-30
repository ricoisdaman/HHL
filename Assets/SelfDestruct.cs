using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float lifetime = 2f; // Time in seconds before the arrow is destroyed

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}
