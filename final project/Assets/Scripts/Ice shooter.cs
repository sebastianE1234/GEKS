using UnityEngine;
using System.Collections;

public class cupidshooter : MonoBehaviour
{
    public GameObject iceBlast;
    public float fireballSpeed = 10f;

    public float fireOffsetX = 1f;
    public float fireOffsetY = 0.5f;
    public float cooldownTime = 4f;

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
        if (playerID == PlayerID.PlayerOne && Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (Time.time - lastShotTime >= cooldownTime)
            {
                bool facingRight = transform.localScale.x > 0;
                Vector2 shootDir = facingRight ? Vector2.right : Vector2.left;
                Vector3 spawnOffset = new Vector3(facingRight ? fireOffsetX : -fireOffsetX, fireOffsetY, 0f);
                Vector3 spawnPos = transform.position + spawnOffset;

                Shoot(shootDir, spawnPos);
                lastShotTime = Time.time;

                if (animator != null)
                {
                    animator.SetBool("isShooting", true);
                    StartCoroutine(ResetShootingBool()); // <-- Automatically reset the bool
                }
            }
        }
    }

    IEnumerator ResetShootingBool()
    {
        // Wait for the animation to finish (e.g. 0.5s)
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("isShooting", false);
    }

    void Shoot(Vector2 direction, Vector3 spawnPosition)
    {
        GameObject fireball = Instantiate(iceBlast, spawnPosition, Quaternion.identity);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = direction.normalized * fireballSpeed;
        }
    }
}
