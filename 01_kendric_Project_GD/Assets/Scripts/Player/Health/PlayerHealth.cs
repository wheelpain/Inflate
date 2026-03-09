using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    public HealthBar healthBar;// reference to the health bar script

    // Start is called before the first frame update
    private void Awake()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        print(currentHealth);
        HealthRefreshUI();
    }

    void Heal(int healAmount)
    {
        currentHealth += healAmount;
        HealthRefreshUI();

    }

    void HealthRefreshUI()
    {
        if (healthBar != null)
        {
            healthBar.Sethealth(currentHealth);
        }
    }
}
