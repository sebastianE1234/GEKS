using System;
using UnityEngine;


public class iceshooter : MonoBehaviour
{
   
    public GameObject FireballPrefab;  // Drag your Fireball prefab here
    public Transform firePoint;        // Where the fireball spawns
    public float fireballSpeed = 10f; // Speed of the fireball

    void Start()
    {
        
    }

    public enum PlayerID { PlayerOne, PlayerTwo }
    public PlayerID playerID;
    void Update()
    {
        if (playerID == PlayerID.PlayerOne && Input.GetKeyDown(KeyCode.B))

            
            {
                Shoot(Vector2.right);
               
            }
        if (playerID == PlayerID.PlayerOne && Input.GetKeyDown(KeyCode.V))
        {
            Shoot(Vector2.left);
        }
    }


    void Shoot(Vector2 direction)
    {
        GameObject fireball = Instantiate(FireballPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction.normalized * fireballSpeed;
        }
    }
}
