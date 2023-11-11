using UnityEngine;
using UnityEngine.AI;

public class PointToPlayer : MonoBehaviour
{
    public string playerTag = "Player";  // ��� ������
    private bool switchedToPointToPlayer = false;  // ���� ��� ������������ ������������
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!switchedToPointToPlayer && other.CompareTag("FirstPoint"))
        {
            // ���� ������ �� ����
            GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

            if (playerObject != null)
            {
                // �������� ��������� NavMeshAgent � ������������� ����� ����
                navMeshAgent.SetDestination(playerObject.transform.position);

                // ������������� ���� � true, ����� �������� ���������� ������������
                switchedToPointToPlayer = true;
            }
        }
    }
}
