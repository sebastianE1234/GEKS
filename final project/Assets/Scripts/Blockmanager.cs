using UnityEngine;
using System.Collections;

public class PlayerBlockAbility : MonoBehaviour
{
    public GameObject blockPrefab;      // Block prefab
    public Transform blockSpawnPoint;   // Spawn point for the block
    public KeyCode blockKey = KeyCode.O; // Key to spawn the block (O for Player 1)
    private bool canSpawnBlock = true;  // Control spawning cooldown

    private void Update()
    {
        // Press 'O' (or other key) to spawn a block if cooldown allows
        if (Input.GetKeyDown(blockKey) && canSpawnBlock)
        {
            SpawnBlock();
        }
    }

    // Spawn a new block at the designated spawn point
    private void SpawnBlock()
    {
        // Instantiate the block at the spawn point
        Instantiate(blockPrefab, blockSpawnPoint.position, blockSpawnPoint.rotation);

        // Set canSpawnBlock to false to initiate cooldown
        canSpawnBlock = false;

        // Start the cooldown coroutine to allow spawning after a set time
        StartCoroutine(ResetSpawnCooldown());
    }

    // Coroutine to handle the cooldown period before the player can spawn another block
    private IEnumerator ResetSpawnCooldown()
    {
        // Wait for the cooldown time (15 seconds by default)
        yield return new WaitForSeconds(15f); // Adjust if necessary
        canSpawnBlock = true;  // Re-enable spawning
    }
}
