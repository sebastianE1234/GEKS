using UnityEngine;

public class ShardShooter : MonoBehaviour
{
    public GameObject ShardsPrefab; // Changed from FireballPrefab
    public float shardSpeed = 10f; // Renamed to reflect "shard"

    public float fireOffsetX = 1f; // Horizontal spawn offset
    public float fireOffsetY = 0.5f; // Vertical spawn offset
    public float cooldownTime = 0.5f;

    private float lastShotTime = -Mathf.Infinity;

    public enum PlayerID { PlayerOne, PlayerTwo }
    public PlayerID playerID;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerID == PlayerID.PlayerOne && Input.GetKeyDown(KeyCode.Alpha9))
        {
            // Optional cooldown logic
            if (Time.time - lastShotTime >= cooldownTime)
            {
                bool facingRight = transform.localScale.x > 0;
                Vector2 shootDir = facingRight ? Vector2.right : Vector2.left;
                Vector3 spawnOffset = new Vector3(facingRight ? fireOffsetX : -fireOffsetX, fireOffsetY, 0f);
                Vector3 spawnPos = transform.position + spawnOffset;

                Shoot(shootDir, spawnPos);
                lastShotTime = Time.time;
            }
        }
    }

    void Shoot(Vector2 direction, Vector3 spawnPosition)
    {
        GameObject shard = Instantiate(ShardsPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = shard.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction.normalized * shardSpeed;
    }
}



