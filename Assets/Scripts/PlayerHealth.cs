using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public float invulnerabilityTime = 1f;
    bool invulnerable;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (invulnerable) return;

        currentHealth -= damage;
        invulnerable = true;

        Invoke(nameof(ResetInvulnerability), invulnerabilityTime);

        if (currentHealth <= 0)
            Die();
    }

    void ResetInvulnerability()
    {
        invulnerable = false;
    }

    void Die()
    {
        GameManager.Instance.GameOver();
        Destroy(gameObject);
    }
}
