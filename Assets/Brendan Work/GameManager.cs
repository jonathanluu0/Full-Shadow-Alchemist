using UnityEngine;

public class GameManager : MonoBehaviour
{
    public void GameOver()
    {
        // Cleanup all experience objects
        GameObject[] experiences = GameObject.FindGameObjectsWithTag("Experience");
        foreach (GameObject experience in experiences)
        {
            Destroy(experience);
        }
        
        // Additional game over logic (e.g., displaying game over UI, stopping the game, etc.)
        Debug.Log("Game Over. All experience objects have been cleaned up.");
    }
}
