using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public int health;
    public int maxHealth = 10;

    public GameObject damageTextPrefab;
    public GameObject objectToSpawn;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject spawnedObject = Instantiate(objectToSpawn, transform.position, Quaternion.identity);

        health = maxHealth;

        SpriteRenderer renderer = spawnedObject.GetComponent<SpriteRenderer>();
        if (renderer != null)
        {
            renderer.enabled = true;
        }
        else
        {
            Debug.LogWarning("No Renderer found on the spawned object.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void TakeDamage(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
            gameOverText.enabled = true;
        }
    }

    public void ShowDamageText(int amount)
    {
        GameObject damageText = Instantiate(damageTextPrefab, transform.position, Quaternion.identity);

        damageText.GetComponent<TextMeshProUGUI>().text = "-" + amount.ToString();

        Debug.Log("Damage text instantiated at: " + damageText.transform.position);

        damageText.transform.position += new Vector3(0, 1, 0);
        
        Destroy(damageText, 10000f);
    }
}
