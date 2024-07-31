using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject experiencePrefab; // Prefab to spawn when enemy dies
    public void Die()
    {
        
        DropExperience();
        Destroy(gameObject);
    }

    private void DropExperience()
    {
        if (experiencePrefab != null)
        {
            Instantiate(experiencePrefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogError("Experience prefab is not assigned.");
        }
    }
}

