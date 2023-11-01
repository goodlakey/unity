using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAII : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага
    public Vector3 spawnPointCoordinates; // Координаты точки появления противников
    public float spawnInterval = 2.0f; // Интервал времени между генерацией

    void Start()
    {
        StartCoroutine(SpawnEnemiesss());
    }

    IEnumerator SpawnEnemiesss()
    {
        while (true)
        {
            GameObject enemy = Instantiate(enemyPrefab, spawnPointCoordinates, Quaternion.identity); // Используем координаты точки появления
            yield return new WaitForSeconds(spawnInterval);

            // Добавьте компонент Collider к вашему игроку и убедитесь, что "Is Trigger" включен.
            // После этого, вы можете использовать OnTrigger в скрипте противника.

            Collider playerCollider = GameObject.FindWithTag("Player").GetComponent<Collider>();
          //  if (playerCollider != null)
           // {
           //     Physics.IgnoreCollision(enemy.GetComponent<Collider>(), playerCollider);
            //}
        }
    }
}
