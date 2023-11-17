using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Spawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага
    public Vector3[] spawnPoints; // Массив координат точек появления противников
    public float spawnInterval = 2.0f; // Интервал времени между генерацией
    public int enemiesPerSpawn = 10;

    void Start()
    {
        StartCoroutine(SpawnEnemyGroups());
    }

    IEnumerator SpawnEnemyGroups()
    {
        while (true)
        {
            SpawnGroup();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void SpawnGroup()
    {
        // Перемешиваем массив координат
        ShuffleArray(spawnPoints);

        // Создаем противников в группе
        for (int i = 0; i < Mathf.Min(enemiesPerSpawn, spawnPoints.Length); i++)
        {
            Instantiate(enemyPrefab, spawnPoints[i], Quaternion.identity);
        }
    }

    void ShuffleArray(Vector3[] array)
    {
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            Vector3 value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
    }
}
