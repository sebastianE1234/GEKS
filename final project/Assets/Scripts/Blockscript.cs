using UnityEngine;

public class Block : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Destroy the block on collision with the fireball
        if (collision.gameObject.CompareTag("Fireball"))
        {
            Destroy(gameObject); // Destroy this block
        }
    }
}
