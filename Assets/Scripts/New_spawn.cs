using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �����
    public Vector3[] spawnPointCoordinates; // ���������� ����� ��������� �����������
    public float groupSpawnInterval = 2.0f; // �������� ������� ����� ��������
    public int enemiesPerGroup = 10;
    public float circleRadius = 1.0f; // ������ �������� ������

    void Start()
    {
        StartCoroutine(SpawnEnemyGroups());
    }

    IEnumerator SpawnEnemyGroups()
    {
        while (true)
        {
            foreach (Vector3 spawnPoint in spawnPointCoordinates)
            {
                GameObject groupLeader = SpawnGroupAtLocation(spawnPoint);

                // ������� ����������� ����� ��� ������
                Vector3 groupCenter = CalculateGroupCenter(groupLeader, enemiesPerGroup);

                // ��������� ���� �������� ������� ����� � ������
                SetGroupDestination(groupLeader, groupCenter);

                yield return null; // ���� ���� ���� ����� ��������� �������
            }

            yield return new WaitForSeconds(groupSpawnInterval);
        }
    }

    GameObject SpawnGroupAtLocation(Vector3 spawnPoint)
    {
        float angleStep = 360f / enemiesPerGroup;

        // ������� ������ ������, ������� ����� ������� ������� ������
        GameObject groupLeader = new GameObject("GroupLeader");
        groupLeader.transform.position = spawnPoint;

        for (int i = 0; i < enemiesPerGroup; i++)
        {
            float angle = i * angleStep;
            float spawnX = spawnPoint.x + Mathf.Sin(Mathf.Deg2Rad * angle) * circleRadius;
            float spawnZ = spawnPoint.z + Mathf.Cos(Mathf.Deg2Rad * angle) * circleRadius;
            Vector3 enemySpawnPosition = new Vector3(spawnX, spawnPoint.y, spawnZ);

            GameObject enemy = Instantiate(enemyPrefab, enemySpawnPosition, Quaternion.identity);

            // ��������� ����� � �������� (������ ������)
            enemy.transform.parent = groupLeader.transform;

            // ������� ��������� ������, ����� ������������� ������������� � ����������
            NavMeshAgent navMeshAgent = enemy.GetComponent<NavMeshAgent>();
            if (navMeshAgent != null)
            {
                navMeshAgent.enabled = false;
                enemy.transform.position = enemySpawnPosition;
                navMeshAgent.enabled = true;
            }
        }

        return groupLeader;
    }

    Vector3 CalculateGroupCenter(GameObject groupLeader, int groupSize)
    {
        // ������� ����������� ����� ��� ������, ��������� ������� ������ � ������ ������
        Vector3 groupCenter = groupLeader.transform.position;
        groupCenter.y = groupLeader.transform.position.y; // ����� ������������� ��������� ������ � �������

        return groupCenter;
    }

    void SetGroupDestination(GameObject groupLeader, Vector3 groupCenter)
    {
        // ������������� ���� �������� ������� ����� � ������ �� ����������� ����� ������
        foreach (Transform enemyTransform in groupLeader.transform)
        {
            NavMeshAgent navMeshAgent = enemyTransform.GetComponent<NavMeshAgent>();
            if (navMeshAgent != null)
            {
                navMeshAgent.SetDestination(groupCenter);
            }
        }
    }
}
