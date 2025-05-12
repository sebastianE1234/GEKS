using UnityEngine;
using System.Collections;

public class ShardShooter : MonoBehaviour
{
    public GameObject ShardsPrefab; // Changed from FireballPrefab
    public float shardSpeed = 10f; // Renamed to reflect "shard"
    public float fireOffsetX = 1f; // Horizontal spawn offset
    public float fireOffsetY = 0.5f; // Vertical spawn offset
    public float cooldownTime = 0.5f;
    public float attackDuration = 3f;

    private float lastShotTime = -Mathf.Infinity;
    private bool isAttacking = false;

    public enum PlayerID { PlayerOne, PlayerTwo }
    public PlayerID playerID;

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {

        {
            // Optional cooldown logic
            if (Time.time - lastShotTime >= cooldownTime)
            {
                if (!isAttacking && Time.time - lastShotTime >= cooldownTime)
                {
                    StartCoroutine(AttackRoutine());
                }

                IEnumerator AttackRoutine()
                {
                    isAttacking = true;
                    animator.SetBool("isAttacking", true);
                    lastShotTime = Time.time;

                    yield return new WaitForSeconds(attackDuration);

                    ShootShard();

                    isAttacking = false;
                    animator.SetBool("isAttacking", false);
                }

                void ShootShard()
                {
                    bool facingRight = transform.localScale.x >= 0;
                    Vector2 shootDirection = facingRight ? Vector2.right : Vector2.left;

                    Vector3 spawnOffset = new Vector3(facingRight ? fireOffsetX : -fireOffsetX, fireOffsetY, 0f);
                    Vector3 spawnPosition = transform.position + spawnOffset;

                    GameObject shard = Instantiate(ShardsPrefab, spawnPosition, Quaternion.identity);

                    Rigidbody2D rb = shard.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        rb.linearVelocity = shootDirection * shardSpeed;
                    }
                }
            }
            bool facingRight = transform.localScale.x > 0;

                Vector2 shootDir = facingRight ? Vector2.right : Vector2.left;
                Vector3 spawnOffset = new Vector3(facingRight ? fireOffsetX : -fireOffsetX, fireOffsetY, 0f);
                Vector3 spawnPos = transform.position + spawnOffset;
            }
        }
    }

    

