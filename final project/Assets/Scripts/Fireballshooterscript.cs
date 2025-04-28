using System;
using UnityEngine;


public class SimpleFireballShooter : MonoBehaviour
{
    public PlayerStats stats;
    public GameObject FireballPrefab;  // Drag your Fireball prefab here
    public Transform firePoint;        // Where the fireball spawns
    public float fireballSpeed = 10f; // Speed of the fireball
    void Start()
    {
        stats = GetComponent<PlayerStats>();
    }

>>>>>>> 4e59cdd1d5b6ce1640f7cb7fc37d4dd876a8d921
    public enum PlayerID { PlayerOne, PlayerTwo }
    public PlayerID playerID;

    void Update()
    {
        if (playerID == PlayerID.PlayerOne && Input.GetKeyDown(KeyCode.B))

            if(stats.ammo > 0)
            {
                Shoot(Vector2.right);
                stats.UseAmmo();
                Debug.Log("Shot fired! Ammo left;" + stats.ammo);
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
 