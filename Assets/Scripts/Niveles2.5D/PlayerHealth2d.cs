using UnityEngine;
using System;

public class PlayerHealth2d : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public event Action<float> OnHealthChanged;

    void Awake()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        OnHealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        Debug.Log("NAVE DESTRUIDA");
        // Aquí puedes poner Game Over
    }

    public float GetHealthNormalized()
    {
        return currentHealth / maxHealth;
    }
}
