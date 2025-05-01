using UnityEngine;

public class fireballshooter_2 : MonoBehaviour
{
    public GameObject FireballPrefab;
    public Transform firePoint; // Place this to the RIGHT of the player
    public float fireballSpeed = 10f;

    public enum PlayerID { PlayerOne, PlayerTwo }
    public PlayerID playerID;

    void Update()
    {
        if (playerID == PlayerID.PlayerTwo && Input.GetKeyDown(KeyCode.P))
        {
            bool facingRight = transform.localScale.x > 0;
            Vector2 shootDir = facingRight ? Vector2.left : Vector2.right;

            // Get correct offset regardless of facing
            float offset = Mathf.Abs(firePoint.localPosition.x);
            Vector3 spawnPos = transform.position + new Vector3(facingRight ? offset : -offset, firePoint.localPosition.y, 0);

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
