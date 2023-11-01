using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform player; // Ссылка на трансформ игрока
    public float moveSpeed = 5.0f; // Скорость движения противника
    public int health = 100; // Здоровье противника

    void Update()
    {
        if (health <= 0) // Проверяем, не умер ли противник
        {
            Destroy(gameObject); // Уничтожаем противника
            return; // Выходим из метода Update
        }

        if (player != null)
        {
            // Вычисляем направление к игроку
            Vector3 direction = (player.position - transform.position).normalized;

            // Перемещаем противника в направлении игрока
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Если нужно, вы также можете использовать поворот, чтобы противник смотрел в сторону игрока
            //transform.rotation = Quaternion.LookRotation(direction);
        }
    }

    // Обработка столкновений с другими коллайдерами
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            health = 0; // Устанавливаем здоровье противника в 0, что означает его смерть
        }
    }
}
