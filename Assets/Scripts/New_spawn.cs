using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага
    public Vector3[] spawnPointCoordinates; // Координаты точек появления противников
    public float groupSpawnInterval = 2.0f; // Интервал времени между группами
    public int enemiesPerGroup = 10;
    public float circleRadius = 1.0f; // Радиус круговой группы

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

                // Находим центральную точку для группы
                Vector3 groupCenter = CalculateGroupCenter(groupLeader, enemiesPerGroup);

                // Назначаем цель движения каждому врагу в группе
                SetGroupDestination(groupLeader, groupCenter);

                yield return null; // Ждем один кадр перед следующей группой
            }

            yield return new WaitForSeconds(groupSpawnInterval);
        }
    }

    GameObject SpawnGroupAtLocation(Vector3 spawnPoint)
    {
        float angleStep = 360f / enemiesPerGroup;

        // Создаем пустой объект, который будет служить лидером группы
        GameObject groupLeader = new GameObject("GroupLeader");
        groupLeader.transform.position = spawnPoint;

        for (int i = 0; i < enemiesPerGroup; i++)
        {
            float angle = i * angleStep;
            float spawnX = spawnPoint.x + Mathf.Sin(Mathf.Deg2Rad * angle) * circleRadius;
            float spawnZ = spawnPoint.z + Mathf.Cos(Mathf.Deg2Rad * angle) * circleRadius;
            Vector3 enemySpawnPosition = new Vector3(spawnX, spawnPoint.y, spawnZ);

            GameObject enemy = Instantiate(enemyPrefab, enemySpawnPosition, Quaternion.identity);

            // Добавляем врага к родителю (лидеру группы)
            enemy.transform.parent = groupLeader.transform;

            // Добавим следующие строки, чтобы предотвратить подпрыгивание и разлетание
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
        // Находим центральную точку для группы, используя позицию лидера и размер группы
        Vector3 groupCenter = groupLeader.transform.position;
        groupCenter.y = groupLeader.transform.position.y; // Может потребоваться коррекция высоты в будущем

        return groupCenter;
    }

    void SetGroupDestination(GameObject groupLeader, Vector3 groupCenter)
    {
        // Устанавливаем цель движения каждого врага в группе на центральную точку группы
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
