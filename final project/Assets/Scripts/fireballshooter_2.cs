using System;
using UnityEngine;


public class fireballshooter_2 : MonoBehaviour
{
    public GameObject FireballPrefab;  // Drag your Fireball prefab here
    public Transform firePoint;        // Where the fireball spawns
    public float fireballSpeed = 10f; // Speed of the fireball
    public int damage = 10; // Amount of damage the fireball deals

    // Update is called once per frame

    public enum PlayerID { PlayerOne, PlayerTwo }
    public PlayerID playerID;
    void Update()
    {

        if (playerID == PlayerID.PlayerTwo && Input.GetKeyDown(KeyCode.L))
        {

            Shoot(Vector2.left);
        }
    }

    void Shoot(Vector2 direction)
    {
        Vector3 spawnOffset = new Vector3(-0.5f, 0f, 0f); // offset in local space
        Vector3 spawnPosition = firePoint.position + firePoint.TransformDirection(spawnOffset);

        GameObject fireball = Instantiate(FireballPrefab, spawnPosition, Quaternion.identity);

        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction.normalized * fireballSpeed;
        }
    }
}
