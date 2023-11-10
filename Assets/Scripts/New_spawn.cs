using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �����
    public Vector3 spawnPointCoordinates1; // ���������� ����� ��������� �����������
    public Vector3 spawnPointCoordinates2; // ���������� ����� ��������� �����������
    public Vector3 spawnPointCoordinates3; // ���������� ����� ��������� �����������
    public float spawnInterval = 2.0f; // �������� ������� ����� ����������

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
            Instantiate(enemyPrefab, spawnPointCoordinates1, Quaternion.identity); // ���������� ���������� ����� ���������
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator SpawnEnemies2()
    {
        while (true)
        {
            Instantiate(enemyPrefab, spawnPointCoordinates2, Quaternion.identity); // ���������� ���������� ����� ���������
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    IEnumerator SpawnEnemies3()
    {
        while (true)
        {
            Instantiate(enemyPrefab, spawnPointCoordinates3, Quaternion.identity); // ���������� ���������� ����� ���������
            yield return new WaitForSeconds(spawnInterval);
        }
    }


}