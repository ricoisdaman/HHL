using UnityEngine;

public class DoorMechanic: MonoBehaviour
{
    private bool isOpen = false;

    // You can use animation or simply translate the door to open/close it
    public void ToggleDoor()
    {
        if (isOpen)
        {
            CloseDoor();
        }
        else
        {
            OpenDoor();
        }
        isOpen = !isOpen;
    }

    private void OpenDoor()
    {
        // Implement opening logic, e.g., move the door, play animation, etc.
        transform.Translate(Vector3.up * 3); // Example: move the door upwards
    }

    private void CloseDoor()
    {
        // Implement closing logic
        transform.Translate(Vector3.down * 3); // Move the door back down
    }
}
