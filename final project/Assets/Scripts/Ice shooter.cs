using System;
using UnityEngine;


public class Iceshooter : MonoBehaviour
{
    public GameObject Iceblastprefab;  // Drag your Fireball prefab here
    public Transform firePoint;        // Where the fireball spawns
    public float iceSpeed = 10f; // Speed of the fireball


    public enum PlayerID { PlayerOne, PlayerTwo }
    public PlayerID playerID;
    void Update()
    {
        if (playerID == PlayerID.PlayerOne && Input.GetKeyDown(KeyCode.B))
        {
            Shoot(Vector2.right);
        }


    }


    void Shoot(Vector2 direction)
    {
        GameObject Iceblast = Instantiate(Iceblastprefab, firePoint.position, Quaternion.identity);
        Physics2D.IgnoreCollision(Iceblast.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Rigidbody2D rb = Iceblast.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction.normalized * iceSpeed;
        }
    }
}
 