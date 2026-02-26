using UnityEngine;

public class EnemyControlStill : MonoBehaviour
{
    public Transform player;
    public float chaseRange = 5f;
    public float moveSpeed = 3f;

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            Vector3 direction = (player.position - transform.position).normalized;

            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}