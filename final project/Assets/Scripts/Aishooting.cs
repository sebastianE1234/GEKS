using UnityEngine;

public class AIShooting : MonoBehaviour
{
    public GameObject fireArrowPrefab;
    public Transform firePoint;
    public float fireCooldown = 2f;
    public float fireRange = 5f;

    private float shootTimer = 0f;
    private AIMovement movementScript;
    private Transform player;

    void Start()
    {
        movementScript = GetComponent<AIMovement>();
        player = movementScript.player;
    }

    void Update()
    {
        if (player == null || fireArrowPrefab == null || firePoint == null) return;

        shootTimer -= Time.deltaTime;
        float distance = Mathf.Abs(player.position.x - transform.position.x);

        if (distance <= fireRange && shootTimer <= 0f)
        {
            Shoot();
            shootTimer = fireCooldown;
        }
    }

    void Shoot()
    {
        Vector2 shootDir = movementScript.IsFacingRight() ? Vector2.right : Vector2.left;
        GameObject arrow = Instantiate(fireArrowPrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D arrowRb = arrow.GetComponent<Rigidbody2D>();
        if (arrowRb != null)
        {
            arrowRb.linearVelocity = shootDir * 10f;
        }

        Debug.Log("AI shot a fire arrow.");
    }
}
