using UnityEngine;

public class SimpleFireballShooter : MonoBehaviour
{
    public GameObject FireballPrefab;  // Fireball prefab
    public Transform firePoint;        // Child empty GameObject placed in front of the player when facing right
    public float fireballSpeed = 10f;

    public enum PlayerID { PlayerOne, PlayerTwo }
    public PlayerID playerID;

    void Update()
    {
        if (playerID == PlayerID.PlayerOne && Input.GetKeyDown(KeyCode.E))
        {
            Vector2 shootDir = transform.localScale.x > 0 ? Vector2.right : Vector2.left;

            // Flip the firePoint position based on facing
            Vector3 spawnPos = firePoint.position;
            spawnPos.x = transform.position.x + (shootDir.x * Mathf.Abs(firePoint.localPosition.x));

            Shoot(shootDir, spawnPos);
        }
    }

    void Shoot(Vector2 direction, Vector3 spawnPosition)
    {
        GameObject fireball = Instantiate(FireballPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction.normalized * fireballSpeed;
        }
    }
}
