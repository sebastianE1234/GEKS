using System;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    public GameObject FireballPrefab;
    public Transform firePoint;
    public float fireballSpeed = 10f;
    public float spawnOffset = 0.5f;

    public enum PlayerID { PlayerOne, PlayerTwo }
    public PlayerID playerID;

    void Update()
    {
        if (playerID == PlayerID.PlayerTwo && Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(Vector2.left);
        }
    }

    void Shoot(Vector2 direction)
    {
        GameObject fireball = Instantiate(FireballPrefab, firePoint.position, Quaternion.identity);
        Vector2 spawnPosition = (Vector2)firePoint.position + direction.normalized * spawnOffset;
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction.normalized * fireballSpeed;  // FIXED here
        }
    }
}
