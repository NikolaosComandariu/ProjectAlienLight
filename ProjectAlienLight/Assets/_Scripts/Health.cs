using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth = 2;
    [SerializeField] private float currentHealth;

    private float normalisedHealth => currentHealth / maxHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public float GetCurrentHealth() { return currentHealth; }
    public float GetNormalisedHealth() { return normalisedHealth; }


    /// <summary>
    /// Increases health, if health is not already full.
    /// </summary>
    /// <param name="health"></param>
    private void Heal(float health)
    {
        if (currentHealth == maxHealth) return;
        currentHealth += health;
    }

    /// <summary>
    /// Decreases health, unless health is already at 0.
    /// </summary>
    /// <param name="damage"></param>
    private void TakeDamage(float damage)
    {
        if (currentHealth <= 0) return;
        currentHealth -= damage;

        if (currentHealth <= 0) Die();
    }

    private void Die()
    {
        // Deal with death sequence.
    }
}
