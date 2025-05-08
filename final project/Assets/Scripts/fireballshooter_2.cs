using UnityEngine;

public class fireballshooter_2 : MonoBehaviour
{
    public GameObject ShardPrefab; // Replace with shard prefab
    public float shardSpeed = 10f;

    public float fireOffsetX = 1f; // Horizontal offset
    public float fireOffsetY = 0.5f; // Vertical offset
    public float cooldownTime = 4f; // Cooldown duration

    private float lastShotTime = -Mathf.Infinity;

    public enum PlayerID { PlayerOne, PlayerTwo }
    public PlayerID playerID;

    void Update()
    {
        if (playerID == PlayerID.PlayerTwo && Input.GetKeyDown(KeyCode.L))
        {
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
        GameObject shard = Instantiate(ShardPrefab, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = shard.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction.normalized * shardSpeed;
        }
    }
}
