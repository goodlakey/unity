using UnityEngine;
using UnityEngine.AI;

public class PointToPoint : MonoBehaviour
{
    public string waypointTag = "FirstPoint";  // Тег точек навигации
    public string playerTag = "Player";  // Тег игрока
    private int currentWaypoint = 0;
    private NavMeshAgent navMeshAgent;
    private bool reachedFirstPoint = false;

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
            Transform targetWaypoint = waypoints[currentWaypoint].transform;

            // Если достигли FirstPoint, сохраняем координату X в переменной
            if (targetWaypoint.CompareTag("FirstPoint"))
            {
                Vector3 currentPosition = transform.position;
                targetWaypoint.position = new Vector3(currentPosition.x, targetWaypoint.position.y, targetWaypoint.position.z);
            }

            navMeshAgent.SetDestination(targetWaypoint.position);
        }
    }

    void Update()
    {
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag(waypointTag);

        if (!reachedFirstPoint && currentWaypoint < waypoints.Length && navMeshAgent.remainingDistance < 5.0f && !navMeshAgent.pathPending)
        {
            // Проверяем, достигли ли FirstPoint
            if (waypoints[currentWaypoint].CompareTag("FirstPoint"))
            {
                Debug.Log("Reached FirstPoint! Switching to the player.");
                SwitchToPlayer();
                reachedFirstPoint = true; // Помечаем, что достигли FirstPoint
            }
            else
            {
                // Переходим к следующей точке, если это не FirstPoint
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
