using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    private int playersInTrigger = 0; // Track the number of players in the trigger

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playersInTrigger++;
            CheckPlayersAndTransition();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playersInTrigger--;
        }
    }

    private void CheckPlayersAndTransition()
    {
        if (playersInTrigger >= 2) // Check if two or more players are in the trigger
        {
            // Load the next level or reset the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
