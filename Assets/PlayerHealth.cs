using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
        Debug.Log(currentHealth);
    }

    private void Die()
    {
        // Handle the player's death here
        Debug.Log("Player died.");
        // You can deactivate the player, trigger a death animation, etc.
    }
}
