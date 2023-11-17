using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public string playerTag = "Player"; // Тег игрока
    private Transform player;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        FindPlayer();
    }

    void Update()
    {
        if (navMeshAgent != null && navMeshAgent.isActiveAndEnabled && player != null)
        {
            navMeshAgent.SetDestination(player.position);
        }
        else
        {
            FindPlayer();
        }
    }

    void FindPlayer()
    {
        // Ищем игрока по тегу
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }
}
