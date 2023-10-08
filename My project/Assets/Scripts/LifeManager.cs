using UnityEngine;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public int startingLives = 3;
    private int currentLives;

    public Text livesText;  // Reference to a UI text element to display lives

    private void Start()
    {
        currentLives = startingLives;
        UpdateLivesText();
    }

    private void UpdateLivesText()
    {
        if (livesText != null)
        {
            livesText.text = "Lives: " + currentLives;
        }
    }

    public void LoseLife()
    {
        currentLives--;

        if (currentLives <= 0)
        {
            GameOver();
        }
        else
        {
            UpdateLivesText();
            // Add any additional logic for losing a life here (e.g., resetting player position, showing animations, etc.).
        }
    }

    private void GameOver()
    {
        // Add your game over logic here (e.g., show game over screen, restart level, etc.).
        Debug.Log("Game Over");
    }

    // You can call this function to add lives (e.g., when collecting a power-up).
    public void GainLife(int amount)
    {
        currentLives += amount;
        UpdateLivesText();
    }
}