using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public int health;
    public int maxHealth = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        health = maxHealth;
        gameOverText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void TakeDamage(int amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
            gameOverText.enabled = true;
        }
    }
}

  
