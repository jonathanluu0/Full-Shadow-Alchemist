using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public float damageCooldown = 1f; // Cooldown period in seconds
    private float lastDamageTime; // Time when the last damage was applied
    private Enemy enemy;
    public Animator animComponent;
    private Collider2D enemyCollider; // Reference to the enemy's collider
    private bool isDead = false; // Flag to check if the enemy is dead

    void Start()
    {
        currentHealth = maxHealth;
        lastDamageTime = -damageCooldown; // Ensure the player can take damage immediately
        enemy = GetComponent<Enemy>();
        enemyCollider = GetComponent<Collider2D>(); // Get the collider component
        Debug.Log("Enemy initialized with " + currentHealth + " health.");
    }

    public void TakeDamage(int amount)
    {
        if (isDead) return; // Prevent taking damage if already dead

        currentHealth -= amount;
        Debug.Log("Enemy took " + amount + " damage, current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return; // Prevent multiple death triggers

        isDead = true;
        Debug.Log("Enemy Died");
        if (enemy != null && animComponent != null)
        {
            animComponent.SetTrigger("die");
            enemyCollider.enabled = false; // Disable the collider
            if (enemy != null)
            {
                enemy.enabled = false; // Disable the enemy movement script
            }
            StartCoroutine(WaitForDeathAnimation());
        }
        else
        {
            Destroy(gameObject); // Fallback in case of missing components
        }
    }

    private IEnumerator WaitForDeathAnimation()
    {
        // Wait for the length of the death animation
        AnimatorStateInfo stateInfo = animComponent.GetCurrentAnimatorStateInfo(0);
        float waitTime = stateInfo.length > 0 ? stateInfo.length : 1f; // Default to 1 second if length is not valid
        yield return new WaitForSeconds(waitTime);

        // Destroy the enemy game object after the animation
        Destroy(gameObject);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (isDead) return; // Prevent interactions if already dead

        Debug.Log("Collision ongoing with " + collision.gameObject.name);

        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time >= lastDamageTime + damageCooldown)
            {
                Debug.Log("Dealing damage to Player");
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(10);
                lastDamageTime = Time.time; // Update the last damage time
            }
        }
    }
}
