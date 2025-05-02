using UnityEngine;

public class heliosshooter : MonoBehaviour
{
    public GameObject fireArrow;
    public float fireballSpeed = 10f;

    public float fireOffsetX = 1f; // Distance to left/right of player
    public float fireOffsetY = 0.5f; // Height of the fireball
    public float cooldownTime = 4f; // Cooldown duration in seconds

    private float lastShotTime = -Mathf.Infinity; // Time since last shot

    public enum PlayerID { PlayerOne, PlayerTwo }
    public PlayerID playerID;

    void Update()
    {
        if (playerID == PlayerID.PlayerTwo && Input.GetKeyDown(KeyCode.L))
        {
            // Check cooldown
            if (Time.time - lastShotTime >= cooldownTime)
            {
                bool facingRight = transform.localScale.x > 0;

                Vector2 shootDir = facingRight ? Vector2.right : Vector2.left;
                Vector3 spawnOffset = new Vector3(facingRight ? fireOffsetX : -fireOffsetX, fireOffsetY, 0f);
                Vector3 spawnPos = transform.position + spawnOffset;

                Shoot(shootDir, spawnPos);
                lastShotTime = Time.time; // Reset cooldown
            }
        }
    }

    void Shoot(Vector2 direction, Vector3 spawnPosition)
    {
        GameObject fireball = Instantiate(fireArrow, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction.normalized * fireballSpeed;
        }
    }
}
