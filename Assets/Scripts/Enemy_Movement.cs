using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public string playerTag = "Player"; // Тег игрока
    public float moveSpeed = 5.0f; // Скорость движения противника
    private Transform player;

    void Update()
    {

        if (player == null)
        {
            // Ищем игрока по тегу
            GameObject playerObject = GameObject.FindWithTag(playerTag);

            if (playerObject != null)
            {
                player = playerObject.transform;
            }
        }

        if (player != null)
        {
            // Вычисляем направление к игроку
            Vector3 direction = (player.position - transform.position).normalized;

            // Перемещаем противника в направлении игрока
            transform.position += direction * moveSpeed * Time.deltaTime;

            // Если нужно, вы также можете использовать поворот, чтобы противник смотрел в сторону игрока
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
