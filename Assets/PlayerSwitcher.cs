using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public CameraFollow cameraFollow;

    private GameObject activePlayer;

    void Start()
    {
        activePlayer = player1;
        player2.SetActive(false);
        cameraFollow.SetTarget(activePlayer.transform);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            SwitchPlayer();
        }
    }

    void SwitchPlayer()
    {
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
        cameraFollow.SetTarget(activePlayer.transform);
    }
}
