using UnityEngine;
using UnityEngine.AI;

public class PointToPoint : MonoBehaviour
{
    public string waypointTag = "FirstPoint";  // Тег точек навигации
    public string playerTag = "Player";  // Тег игрока
    private int currentWaypoint = 0;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        SetDestination();
    }

    void SetDestination()
    {
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag(waypointTag);

        if (currentWaypoint < waypoints.Length)
        {
            navMeshAgent.SetDestination(waypoints[currentWaypoint].transform.position);
        }
    }

    void Update()
    {
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag(waypointTag);

        if (currentWaypoint < waypoints.Length && navMeshAgent.remainingDistance < 5.0f && !navMeshAgent.pathPending)
        {
            // Проверяем, является ли текущая цель последней точкой
            if (currentWaypoint == waypoints.Length - 1)
            {
                // Выполняем какие-то дополнительные действия для последней точки
                Debug.Log("Reached the last waypoint! Switching to the player.");

                // Переключаемся на игрока
                SwitchToPlayer();
            }
            else
            {
                // Переходим к следующей точке, если это не последняя
                currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
                SetDestination();
            }
        }
    }

    void SwitchToPlayer()
    {
        // Ищем игрока по тегу
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

        if (playerObject != null)
        {
            // Устанавливаем цель на игрока
            navMeshAgent.SetDestination(playerObject.transform.position);
        }
    }
}
