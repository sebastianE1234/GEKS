using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DamagePopup : MonoBehaviour
{
    public GameObject damageTextPrefab; // The damage popup prefab (set in the Inspector)

    // This function will create a damage popup at the position of the player.
    public void ShowDamagePopup(Vector3 position, int damageAmount)
    {
        GameObject damageText = Instantiate(damageTextPrefab, position, Quaternion.identity);

        // Set the text to the damage amount
        Text textComponent = damageText.GetComponent<Text>();
        textComponent.text = $"-{damageAmount}";

        // Move the text upward over time to simulate a floating effect
        StartCoroutine(FloatingTextEffect(damageText));
    }

    private IEnumerator FloatingTextEffect(GameObject damageText)
    {
        Vector3 startPos = damageText.transform.position;
        float moveSpeed = 1.5f;
        float fadeSpeed = 0.5f;

        // Move up and fade out
        float timeElapsed = 0f;
        Text textComponent = damageText.GetComponent<Text>();
        Color initialColor = textComponent.color;

        while (timeElapsed < 1f)
        {
            damageText.transform.position = startPos + Vector3.up * moveSpeed * timeElapsed;
            textComponent.color = new Color(initialColor.r, initialColor.g, initialColor.b, Mathf.Lerp(1, 0, timeElapsed / fadeSpeed));
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        // Destroy the damage text after animation
        Destroy(damageText);
    }
}
