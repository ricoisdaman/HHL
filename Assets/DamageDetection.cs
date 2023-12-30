using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetection : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        HarmfulObject harmfulObject = collision.gameObject.GetComponent<HarmfulObject>();
        if (harmfulObject != null)
        {
            PlayerHealth playerHealth = GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(harmfulObject.damageAmount);
            }
            else
            {
                Debug.LogError("PlayerHealth component not found!");
            }
        }
    }

}
