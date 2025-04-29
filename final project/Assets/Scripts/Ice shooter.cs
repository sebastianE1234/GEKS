using System;
using UnityEngine;

public class iceshooter : MonoBehaviour
{
    public GameObject FireballPrefab;  // Drag your Fireball prefab here
    public Transform firePoint;        // Where the fireball spawns
    public float fireballSpeed = 10f;  // Speed of the fireball

    public enum PlayerID { PlayerOne, PlayerTwo }
    public PlayerID playerID;

    void Update()
    {
        if (playerID == PlayerID.PlayerOne)
        {
            // Shoot right with 'B'
            if (Input.GetKeyDown(KeyCode.B))
            {
                Shoot(Vector2.right);  // Shoot to the right
            }

            // Shoot left with 'V'
            if (Input.GetKeyDown(KeyCode.V))
            {
                Shoot(Vector2.left);  // Shoot to the left
            }
        }
    }

    void Shoot(Vector2 direction)
    {
        // Instantiate fireball at the firePoint's position
        GameObject fireball = Instantiate(FireballPrefab, firePoint.position, Quaternion.identity);

        // Get Rigidbody2D component and set its velocity
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Apply the velocity in the specified direction
            rb.linearVelocity = direction * fireballSpeed;
        }
    }
}
