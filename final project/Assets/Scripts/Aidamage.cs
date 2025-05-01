using UnityEngine;

public class AIDamageHandler : MonoBehaviour
{
    private AIHealth healthScript;

    void Start()
    {
        healthScript = GetComponent<AIHealth>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Ice blast"))
        {
            healthScript.TakeDamage(20);
            Destroy(collision.gameObject);
        }
    }
}
