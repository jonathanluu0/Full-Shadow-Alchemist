using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public float damageCooldown = 1f; // Cooldown period in seconds
    private float lastDamageTime; // Time when the last damage was applied
    private Enemy enemy;

    void Start()
    {
        currentHealth = maxHealth;
        lastDamageTime = -damageCooldown; // Ensure the player can take damage immediately
        enemy = GetComponent<Enemy>();
        Debug.Log("Enemy initialized with " + currentHealth + " health.");
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Enemy took " + amount + " damage, current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Died");
        if (enemy != null)
        {
            enemy.Die(); // Call the Die method in the Enemy class
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
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
