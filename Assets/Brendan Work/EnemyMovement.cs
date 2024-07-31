using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform target; // The target for the enemy to follow
    public float speed = 2f; // Speed of the enemy
    private bool isFacingRight = true; // Track the current facing direction

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

            // Flip the sprite based on the relative position of the player
            if (target.position.x < transform.position.x && isFacingRight)
            {
                Flip();
            }
            else if (target.position.x > transform.position.x && !isFacingRight)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1; // Invert the x scale to flip the sprite
        transform.localScale = theScale;
    }
}
