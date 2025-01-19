using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] HealthBar healthBar;
    float maxHealth = 100f;
    float currentHealth;
   
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("asteroid"))
        {
            currentHealth -=10;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health doesn't go negative
            healthBar.SetHealth(currentHealth, maxHealth);
            Debug.Log("Health = "+currentHealth);
        }
    }
}
