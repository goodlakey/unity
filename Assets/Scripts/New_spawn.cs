using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �����
    public Vector3 spawnPointCoordinates1; // ���������� ����� ��������� �����������
    public Vector3 spawnPointCoordinates2; // ���������� ����� ��������� �����������
    public Vector3 spawnPointCoordinates3; // ���������� ����� ��������� �����������
    public Vector3 spawnPointCoordinates4; // ���������� ����� ��������� �����������
    public Vector3 spawnPointCoordinates5; // ���������� ����� ��������� �����������
    public float spawnInterval = 2.0f; // �������� ������� ����� ����������
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
                Instantiate(enemyPrefab, spawnPointCoordinates1, Quaternion.identity); // ���������� ���������� ����� ���������
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
                Instantiate(enemyPrefab, spawnPointCoordinates2, Quaternion.identity); // ���������� ���������� ����� ���������
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
                Instantiate(enemyPrefab, spawnPointCoordinates3, Quaternion.identity); // ���������� ���������� ����� ���������
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
                Instantiate(enemyPrefab, spawnPointCoordinates4, Quaternion.identity); // ���������� ���������� ����� ���������
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
                Instantiate(enemyPrefab, spawnPointCoordinates5, Quaternion.identity); // ���������� ���������� ����� ���������
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }


}