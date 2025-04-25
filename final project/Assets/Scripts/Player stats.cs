using TMPro; // If you're using TextMeshPro
using UnityEngine.UI; // if you're using standard Text
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int health = 100;
    public int maxHealth = 100;
    public int ammo = 10;
    public int maxAmmo = 30;

    public TextMeshProUGUI ammoText; // Drag your UI text here in Inspector

    void Start()
    {
        UpdateAmmoUI();
    }

    public void AddAmmo(int amount)
    {
        ammo = Mathf.Min(ammo + amount, maxAmmo);
        Debug.Log("Ammo: " + ammo);
    }

    public void UseAmmo()
    {
        if (ammo > 0)
        {
            ammo--;
            UpdateAmmoUI();
        }
    }

    void UpdateAmmoUI()
    {
        ammoText.text = "Ammo: " + ammo + " / " + maxAmmo;
    }
}
