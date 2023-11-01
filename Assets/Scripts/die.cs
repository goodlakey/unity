using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    public int health = 100; // Здоровье противника

    // Метод, который вызывается при получении урона
    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            // Если здоровье меньше или равно 0, уничтожаем противника
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bullet"))
        {
            // Если столкнулись с пулей, получаем урон от пули
            Bullet_Movement bullet = other.GetComponent<Bullet_Movement>();
            if (bullet != null)
            {
                TakeDamage(bullet.damage);
            }
        }
    }
}