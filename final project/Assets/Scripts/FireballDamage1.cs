using UnityEngine;

public class FireballDamage1 : MonoBehaviour
{
    public PlayerHealth pHealth;
    public float damage; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("P1");
        if (player != null)
        {
            pHealth = player.GetComponent<PlayerHealth>();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("P1"))
        {
            pHealth.health -= damage; 
        }
    }
}