using UnityEngine;

public class fireballshooter : MonoBehaviour
{
    public GameObject FireballPrefab;
    public float fireballSpeed = 10f;

    public float fireOffsetX = 1f; // Distance to left/right of player
    public float fireOffsetY = 0.5f; // Height of the fireball
    public float cooldownTime = 0.5f; // Cooldown duration in seconds

    private float lastShotTime = -Mathf.Infinity; // Track last shot time

    public enum PlayerID { PlayerOne, PlayerTwo }
    public PlayerID playerID;

    private Animator animator; // Reference to Animator

    void Start()
    {
        animator = GetComponent<Animator>(); // Get Animator from this GameObject
    }

    void Update()
    {
        if (playerID == PlayerID.PlayerOne && Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Time.time - lastShotTime >= cooldownTime)
            {
                // Set isShooting to true
                if (animator != null)
                {
                    animator.SetBool("isShooting", true);
                }

                bool facingRight = transform.localScale.x > 0;
                Vector2 shootDir = facingRight ? Vector2.right : Vector2.left;
                Vector3 spawnOffset = new Vector3(facingRight ? fireOffsetX : -fireOffsetX, fireOffsetY, 0f);
                Vector3 spawnPos = transform.position + spawnOffset;

                Shoot(shootDir, spawnPos);
                lastShotTime = Time.time;

                // Reset isShooting after a short delay
                StartCoroutine(ResetShootingBool());
            }
        }
    }

    System.Collections.IEnumerator ResetShootingBool()
    {
        yield return new WaitForSeconds(0.2f); // Adjust to match your animation length if needed
        if (animator != null)
        {
            animator.SetBool("isShooting", false);
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
