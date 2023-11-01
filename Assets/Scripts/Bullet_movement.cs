
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bullet_Movement : MonoBehaviour
{
    public int damage = 10; // Урон пули
    private float speed;
    public void Initialize(float bulletSpeed)
    {
        speed = bulletSpeed;
    }
    void Start()
    {
        // Задаем начальную скорость пули, например, вправо
        transform.rotation = Quaternion.Euler(0, -90, 0);
         // Двигаем пулю только по координате Z
        transform.Translate(Vector3.left * speed * Time.deltaTime); // Измените на соответствующие значения
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Если пуля столкнулась с врагом, уничтожаем врага
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.GetDamage(damage); // Вызываем метод TakeDamage у врага
            }

             // Уничтожаем пулю после попадания в врага
            Destroy(gameObject);
        }
    }
}
