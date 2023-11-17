using UnityEngine;
using UnityEngine.AI;

public class PointToPoint : MonoBehaviour
{
    public string waypointTag = "FirstPoint";  // ��� ����� ���������
    public string playerTag = "Player";  // ��� ������
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

            // ���� �������� FirstPoint, ��������� ���������� X � ����������
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
            // ���������, �������� �� FirstPoint
            if (waypoints[currentWaypoint].CompareTag("FirstPoint"))
            {
                Debug.Log("Reached FirstPoint! Switching to the player.");
                SwitchToPlayer();
                reachedFirstPoint = true; // ��������, ��� �������� FirstPoint
            }
            else
            {
                // ��������� � ��������� �����, ���� ��� �� FirstPoint
                currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
                SetDestination();
            }
        }
    }

    void SwitchToPlayer()
    {
        // ���� ������ �� ����
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

        if (playerObject != null)
        {
            // ������������� ���� �� ������
            navMeshAgent.SetDestination(playerObject.transform.position);
        }
    }
}
