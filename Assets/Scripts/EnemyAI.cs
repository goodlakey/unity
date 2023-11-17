using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public string playerTag = "Player";
    public string waypointTag = "FirstPoint";
    private Transform player;
    private NavMeshAgent navMeshAgent;
    private bool switchedToPointToPlayer = false;
    private int currentWaypoint = 0;

    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        FindPlayer();
        SetDestination();
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (navMeshAgent != null && navMeshAgent.isActiveAndEnabled)
        {
            if (!switchedToPointToPlayer && player != null)
            {
                navMeshAgent.SetDestination(player.position);
                switchedToPointToPlayer = true;
            }
            else
            {
                SetDestination();
            }
        }
        else
        {
            FindPlayer();
        }
    }

    void FindPlayer()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag(playerTag);

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void SetDestination()
    {
        GameObject[] waypoints = GameObject.FindGameObjectsWithTag(waypointTag);

        if (currentWaypoint < waypoints.Length && navMeshAgent.remainingDistance < 0.1f && !navMeshAgent.pathPending)
        {
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            navMeshAgent.SetDestination(waypoints[currentWaypoint].transform.position);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Реализуйте логику смерти противника (например, анимацию и уничтожение объекта)
        Destroy(gameObject);
    }
}
