using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага
    public Vector3 spawnPointCoordinates1; // Координаты точки появления противников
    public Vector3 spawnPointCoordinates2; // Координаты точки появления противников
    public Vector3 spawnPointCoordinates3; // Координаты точки появления противников
    public float spawnInterval = 2.0f; // Интервал времени между генерацией

    void Start()
    {
        StartCoroutine(SpawnEnemies1());
        StartCoroutine(SpawnEnemies2());
        StartCoroutine(SpawnEnemies3());
    }

    IEnumerator SpawnEnemies1()
    {
        while (true)
        {
            Instantiate(enemyPrefab, spawnPointCoordinates1, Quaternion.identity); // Используем координаты точки появления
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator SpawnEnemies2()
    {
        while (true)
        {
            Instantiate(enemyPrefab, spawnPointCoordinates2, Quaternion.identity); // Используем координаты точки появления
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator SpawnEnemies3()
    {
        while (true)
        {
            Instantiate(enemyPrefab, spawnPointCoordinates3, Quaternion.identity); // Используем координаты точки появления
            yield return new WaitForSeconds(spawnInterval);
        }
    }


}