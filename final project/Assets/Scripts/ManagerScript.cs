using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;  // Reference to the Player prefab
    private GameObject player;       // Reference to the actual player object

    void Start()
    {
        // Instantiate the player prefab and position it in the scene
        player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);

        // Optionally set the player's tag if needed
        player.tag = "P1";
    }
}
