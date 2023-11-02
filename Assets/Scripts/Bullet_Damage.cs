using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage = 10; // Урон, наносимый пулей

    void OnCollisionEnter(Collision collision)
    {
        // Проверяем, столкнулась ли пуля с врагом
        EnemyHealth enemy = collision.gameObject.GetComponent<EnemyHealth>();

        if (enemy != null)
        {
            // Наносим урон врагу
            enemy.TakeDamage(damage);
        }

        // Уничтожаем пулю
        Destroy(gameObject);
    }
}
