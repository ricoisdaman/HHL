using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    public Transform holdPoint; // The point where the object will be held
    private GameObject heldObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldObject == null)
            {
                RaycastHit hit;
                Vector3 rayOrigin = transform.position;
                Vector3 rayDirection = transform.right;

                Debug.DrawRay(rayOrigin, rayDirection * 10f, Color.red, 10f); // Draws a red line in the Scene view
                if (Physics.Raycast(transform.position, transform.right, out hit, 15f))
                {
                    Debug.Log("Raycast hit: " + hit.collider.gameObject.name);
                    if (hit.collider.gameObject.CompareTag("Pickable"))
                    {
                        PickupObject(hit.collider.gameObject);
                    }
                }
                else
                {
                    Debug.Log("Raycast did not hit");
                }
            }
            else
            {
                DropObject();
            }
        }
    }


    void PickupObject(GameObject obj)
    {
        heldObject = obj;
        obj.transform.SetParent(holdPoint);
        obj.transform.position = holdPoint.position;

        Rigidbody objRigidbody = obj.GetComponent<Rigidbody>();
        if (objRigidbody != null)
        {
            objRigidbody.isKinematic = true; // Disable physics
            objRigidbody.detectCollisions = false; // Optionally disable collision detection
        }
    }

    void DropObject()
    {
        if (heldObject != null)
        {
            Rigidbody objRigidbody = heldObject.GetComponent<Rigidbody>();
            if (objRigidbody != null)
            {
                objRigidbody.isKinematic = false; // Re-enable physics
                objRigidbody.detectCollisions = true; // Re-enable collision detection
                objRigidbody.velocity = Vector3.zero; // Reset velocity
                objRigidbody.angularVelocity = Vector3.zero; // Reset angular velocity
            }

            heldObject.transform.SetParent(null);
            heldObject = null;
        }
    }

}
