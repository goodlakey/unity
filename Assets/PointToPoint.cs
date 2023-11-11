using UnityEngine;
using UnityEngine.AI;

public class PointToPoint : MonoBehaviour
{
    public string waypointTag = "FirstPoint";  // ��� ����� ���������
    public string playerTag = "Player";  // ��� ������
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
            // ���������, �������� �� ������� ���� ��������� ������
            if (currentWaypoint == waypoints.Length - 1)
            {
                // ��������� �����-�� �������������� �������� ��� ��������� �����
                Debug.Log("Reached the last waypoint! Switching to the player.");

                // ������������� �� ������
                SwitchToPlayer();
            }
            else
            {
                // ��������� � ��������� �����, ���� ��� �� ���������
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
