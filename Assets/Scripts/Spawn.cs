using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага
    public Vector3 spawnPointCoordinates; // Координаты точки появления противников
    public float spawnInterval = 2.0f; // Интервал времени между генерацией

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Instantiate(enemyPrefab, spawnPointCoordinates, Quaternion.identity); // Используем координаты точки появления
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}