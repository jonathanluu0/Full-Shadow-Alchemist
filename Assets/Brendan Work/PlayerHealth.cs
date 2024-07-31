using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public GameManager gameManager;
    
    void Start()
    {
        currentHealth = maxHealth;
        Debug.Log("Player starts with " + currentHealth + " health.");
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        Debug.Log("Player took " + amount + " damage, current health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void IncreaseHealth(int amount)
    {
        maxHealth += amount;
        currentHealth += amount;
        Debug.Log("Health increased to: " + maxHealth);
    }

    void Die()
    {
        Debug.Log("Player Died");
        #if UNITY_EDITOR
            gameManager.GameOver();
            UnityEditor.EditorApplication.isPlaying = false;
            gameManager.GameOver();
        #else
            gameManager.GameOver();
            Application.Quit();
            gameManager.GameOver();
        #endif
    }
}
