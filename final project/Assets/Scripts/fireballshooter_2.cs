using UnityEngine;
using System.Collections;

public class ShardShooter : MonoBehaviour
{
    public GameObject ShardsPrefab;
    public float shardSpeed = 10f;
    public float fireOffsetX = 1f;
    public float fireOffsetY = 0.5f;
    public float cooldownTime = 0.5f;
    public float attackDuration = 0.5f; // Shorter attack duration for a more responsive feel

    private float lastShotTime = -Mathf.Infinity;
    private bool isAttacking = false; // Track if an attack is in progress

    public enum PlayerID { PlayerOne, PlayerTwo }
    public PlayerID playerID;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Only trigger the attack if the cooldown has passed and the attack button is pressed
        if (Time.time - lastShotTime >= cooldownTime && !isAttacking)
        {
            if (Input.GetKeyDown(KeyCode.Alpha9)) // Replace with any input you want (e.g., mouse click, button, etc.)
            {
                StartCoroutine(AttackRoutine());
            }
        }
    }

    IEnumerator AttackRoutine()
    {
        isAttacking = true; // Start attacking
        animator.SetBool("isAttacking", true); // Trigger attack animation
        lastShotTime = Time.time;

        // Wait for the attack duration to complete
        yield return new WaitForSeconds(attackDuration);

        // Shoot the shard after waiting
        ShootShard();

        // End attack and reset animation
        isAttacking = false;
        animator.SetBool("isAttacking", false); // Stop attacking animation and return to idle
    }

    void ShootShard()
    {
        bool facingRight = transform.localScale.x >= 0;
        Vector2 shootDirection = facingRight ? Vector2.right : Vector2.left;

        Vector3 spawnOffset = new Vector3(facingRight ? fireOffsetX : -fireOffsetX, fireOffsetY, 0f);
        Vector3 spawnPosition = transform.position + spawnOffset;

        // Instantiate the shard (projectile)
        GameObject shard = Instantiate(ShardsPrefab, spawnPosition, Quaternion.identity);

        Rigidbody2D rb = shard.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = shootDirection * shardSpeed; // Set the velocity of the shard
        }
    }
}
