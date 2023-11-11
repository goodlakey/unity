using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага
    public Vector3 spawnPointCoordinates1; // Координаты точки появления противников
    public Vector3 spawnPointCoordinates2; // Координаты точки появления противников
    public Vector3 spawnPointCoordinates3; // Координаты точки появления противников
    public Vector3 spawnPointCoordinates4; // Координаты точки появления противников
    public Vector3 spawnPointCoordinates5; // Координаты точки появления противников
    public float spawnInterval = 2.0f; // Интервал времени между генерацией
    public int enemiesPerSpawn = 10;

    void Start()
    {
        StartCoroutine(SpawnEnemies1());
        StartCoroutine(SpawnEnemies2());
        StartCoroutine(SpawnEnemies3());
        StartCoroutine(SpawnEnemies4());
        StartCoroutine(SpawnEnemies5());
    }

    IEnumerator SpawnEnemies1()
    {
        while (true)
        {
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                Instantiate(enemyPrefab, spawnPointCoordinates1, Quaternion.identity); // Используем координаты точки появления
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator SpawnEnemies2()
    {
        while (true)
        {
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                Instantiate(enemyPrefab, spawnPointCoordinates2, Quaternion.identity); // Используем координаты точки появления
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator SpawnEnemies3()
    {
        while (true)
        {
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                Instantiate(enemyPrefab, spawnPointCoordinates3, Quaternion.identity); // Используем координаты точки появления
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    
    IEnumerator SpawnEnemies4()
    {
        while (true)
        {
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                Instantiate(enemyPrefab, spawnPointCoordinates4, Quaternion.identity); // Используем координаты точки появления
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    
    IEnumerator SpawnEnemies5()
    {
        while (true)
        {
            for (int i = 0; i < enemiesPerSpawn; i++)
            {
                Instantiate(enemyPrefab, spawnPointCoordinates5, Quaternion.identity); // Используем координаты точки появления
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }


}