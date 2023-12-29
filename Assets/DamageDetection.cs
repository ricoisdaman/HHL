using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDetection : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Harmful"))
        {
            int damage = collision.gameObject.GetComponent<HarmfulObject>().damageAmount;
            GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

}
