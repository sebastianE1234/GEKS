using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health, MaxHealth;

    [SerializeField]
    private HealthbarUI healthBar;
     // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthBar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("t"))
        {
            SetHealth(-20f);
        }

        if (Input.GetKeyDown("f"))
        {

            SetHealth(20f);
        }
    }

    public void SetHealth(float healthChange)
    {
        health += healthChange;
        health = Mathf.Clamp(health, 0, MaxHealth);

        healthBar.SetHealth(health);
    }
}
