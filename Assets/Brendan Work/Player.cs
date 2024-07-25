using UnityEngine;

public class Player : MonoBehaviour
{
    public int level = 0;
    public float experience = 0;
    public float experienceToNextLevel = 100;
    public ExperienceBar experienceBar; // Reference to the ExperienceBar component

    void Start()
    {
        UpdateExperienceBar();
    }

    public void GainExperience(float amount)
    {
        experience += amount;
        if (experience >= experienceToNextLevel)
        {
            LevelUp();
        }
        UpdateExperienceBar();
    }

    void LevelUp()
    {
        level++;
        experience = 0;
        experienceToNextLevel += 50; // Increase required experience for next levels
        UpdateExperienceBar();
    }

    void UpdateExperienceBar()
    {
        if (experienceBar != null)
        {
            experienceBar.UpdateExperienceBar(experience, experienceToNextLevel);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Experience"))
        {
            int expAmount = other.gameObject.GetComponent<Experience>().amount;
            GainExperience(expAmount);
            Destroy(other.gameObject);
        }
    }
}
