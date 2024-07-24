using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target; // The target for the enemy to follow
    public float speed = 2f; // Speed of the enemy

    void Start()
    {
        target = GameObject.FindWithTag("Player").transform; // Ensure your player has the "Player" tag
    }

    void Update()
    {
        if (target != null)
        {
            Vector2 direction = (target.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
