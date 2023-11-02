using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Максимальное здоровье противника
    private int currentHealth; // Текущее здоровье противника

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Реализуйте логику смерти противника (например, анимацию и уничтожение объекта)
        Destroy(gameObject);
    }
}
