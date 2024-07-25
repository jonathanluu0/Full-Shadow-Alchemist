using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public Slider experienceSlider; // Reference to the UI Slider
    private int currentLevel = 1;
    private float currentExperience = 0;
    private float experienceNeeded = 100;

    public void GainExperience(float amount)
    {
        currentExperience += amount;
        if (currentExperience >= experienceNeeded)
        {
            LevelUp();
        }
        UpdateExperienceBar(currentExperience, experienceNeeded);
    }

    void LevelUp()
    {
        currentExperience = 0;
        currentLevel++;
        experienceNeeded *= 1.5f; // Increase the experience needed for the next level
        UpdateExperienceBar(currentExperience, experienceNeeded);
    }

    public void UpdateExperienceBar(float currentExperience, float experienceNeeded)
    {
        experienceSlider.value = currentExperience / experienceNeeded;
    }
}
