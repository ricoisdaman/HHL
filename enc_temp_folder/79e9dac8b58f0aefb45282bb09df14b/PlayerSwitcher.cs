using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    private GameObject activePlayer;

    void Start()
    {
        // Set the initial active player
        activePlayer = player1;
        player2.SetActive(false);
    }

    void Update()
    {
        // Check for the switch button press (assuming it's the space bar)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchPlayer();
        }
    }

    void SwitchPlayer()
    {
        // Switch the active player instantly
        activePlayer.SetActive(false);

        if (activePlayer == player1)
        {
            activePlayer = player2;
        }
        else
        {
            activePlayer = player1;
        }

        activePlayer.SetActive(true);
    }
}
