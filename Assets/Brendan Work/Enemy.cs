using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject experiencePrefab; // Prefab to spawn when enemy dies
    public int experienceAmount = 10; // Amount of experience to drop

    private void OnDestroy()
    {
        DropExperience();
    }

    private void DropExperience()
    {
        Instantiate(experiencePrefab, transform.position, Quaternion.identity);
    }
}

