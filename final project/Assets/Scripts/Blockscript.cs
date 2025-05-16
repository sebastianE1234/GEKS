using UnityEngine;

public class Block : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        // Destroy the block on collision with the fireball
        if (collision.gameObject.tag == "Fireball")
        if (collision.gameObject.tag == "Shard")
        {
            Destroy(gameObject);

        }


    }
}
