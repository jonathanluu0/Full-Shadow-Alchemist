using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public int damageAmount; // Amount of damage this projectile deals
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the collided object has a health component
        var health = collision.gameObject.GetComponent<EnemyHealth>();
        if (health != null)
        {
            
            // Deal damage to the object
            health.TakeDamage(damageAmount);
        }

        // Optionally destroy the projectile after it hits something
        Destroy(gameObject);
    }
}
