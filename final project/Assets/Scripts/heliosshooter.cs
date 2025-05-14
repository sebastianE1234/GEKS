using UnityEngine;
using System.Collections;

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

    // Animator reference
    private Animator animator;

    // A boolean for attack animation (you should set this in your Animator as well)
    private bool isAttacking;

    void Start()
    {
        // Get the Animator component from the player GameObject
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (playerID == PlayerID.PlayerTwo && Input.GetKeyDown(KeyCode.Alpha9))
        {
            // Check cooldown
            if (Time.time - lastShotTime >= cooldownTime)
            {
                // Trigger attack animation
                isAttacking = true;
                animator.SetBool("isAttacking", isAttacking); // Set "isAttacking" in the Animator to true

                // Start coroutine to delay shooting the fire arrow
                StartCoroutine(ShootAfterAnimation());

                lastShotTime = Time.time; // Reset cooldown

                // Reset the "isAttacking" bool after the animation ends (or after a delay)
                StartCoroutine(ResetAttackFlag());
            }
        }
    }

    // Coroutine to delay the shooting of the fire arrow
    private IEnumerator ShootAfterAnimation()
    {
        // Wait for the duration of the attack animation (5 seconds)
        yield return new WaitForSeconds(1f); // Wait for 5 seconds

        // Now, shoot the fire arrow
        bool facingRight = transform.localScale.x > 0;
        Vector2 shootDir = facingRight ? Vector2.right : Vector2.left;
        Vector3 spawnOffset = new Vector3(facingRight ? fireOffsetX : -fireOffsetX, fireOffsetY, 0f);
        Vector3 spawnPos = transform.position + spawnOffset;

        Shoot(shootDir, spawnPos);
    }

    // Function to shoot the fire arrow
    void Shoot(Vector2 direction, Vector3 spawnPosition)
    {
        GameObject fireball = Instantiate(fireArrow, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction.normalized * fireballSpeed; // Fix typo: linearVelocity -> velocity
        }
    }

    private IEnumerator ResetAttackFlag()
    {
        // Wait for the duration of the attack animation (adjust based on animation length)
        yield return new WaitForSeconds(1f); // Change this to match your attack animation duration

        // Reset isAttacking to false after the animation is finished
        isAttacking = false;
        animator.SetBool("isAttacking", isAttacking);
    }
}
