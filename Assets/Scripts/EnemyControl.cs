using UnityEngine;
using UnityEngine.AI;

public class EnemyControl : MonoBehaviour
{
    public Transform[] patrolPoints;   
    public float chaseRange = 5f;      
    public Transform player;           

    private NavMeshAgent agent;
    private int currentPatrolIndex = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (patrolPoints.Length > 0)
            agent.SetDestination(patrolPoints[currentPatrolIndex].position);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
                GoToNextPatrolPoint();
        }
    }

    void GoToNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;

        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
    }
}
