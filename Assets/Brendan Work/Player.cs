using UnityEngine;
using ClearSky;

public class Player : MonoBehaviour
{
    public int level = 0;
    public float experience = 0;
    public float experienceToNextLevel = 100;
    public ExperienceBar experienceBar;
    public GameObject cardSelectionUI;
    public Card[] cardOptions;

    void Start()
    {
        UpdateExperienceBar();
    }

    void Update()
    {
        if (Time.timeScale == 0) return; // Skip input handling if the game is paused
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
        experienceToNextLevel += 50;
        UpdateExperienceBar();
        ShowCardSelection();
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
        if (other.CompareTag("Experience"))
        {
            Experience experience = other.GetComponent<Experience>();
            if (experience != null)
            {
                GainExperience(experience.amount);
                Destroy(other.gameObject);
            }
        }
    }

    void ShowCardSelection()
    {
        cardSelectionUI.SetActive(true);
        Time.timeScale = 0f; // Pause the game
    }

    public void OnCardSelected(Card selectedCard)
    {
        selectedCard.ApplyCardEffect(this.gameObject);
        cardSelectionUI.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }
}
