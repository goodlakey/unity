using UnityEngine;
using UnityEngine.AI;

public class PointToPlayer : MonoBehaviour
{
    public string playerTag = "Player";  // Тег игрока
    private bool switchedToPointToPlayer = false;  // Флаг для отслеживания переключения
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (!switchedToPointToPlayer && other.CompareTag("FirstPoint"))
        {
            // Ищем игрока по тегу
            GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

            if (playerObject != null)
            {
                // Получаем компонент NavMeshAgent и устанавливаем новую цель
                navMeshAgent.SetDestination(playerObject.transform.position);

                // Устанавливаем флаг в true, чтобы избежать повторного переключения
                switchedToPointToPlayer = true;
            }
        }
    }
}
