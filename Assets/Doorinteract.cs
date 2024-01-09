using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorinteract : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("open door please");
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, 2f))
            {
                if (hit.collider.CompareTag("Door"))
                {
                    hit.collider.GetComponent<Door>().ToggleDoor();
                }
            }
        }
    }
}