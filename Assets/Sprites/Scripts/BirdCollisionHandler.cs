using UnityEngine;
using TMPro; // Add this namespace for TextMeshPro

public class BirdCollisionHandler : MonoBehaviour
{
    public MenuController menuController; // Reference to the MenuController script
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI for displaying the score
    private int score; // Current score

    void Start()
    {
        score = 0; // Initialize score
        UpdateScoreUI(); // Update the UI on start
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pipe") || collision.gameObject.CompareTag("Ground"))
        {
            // Trigger the Game Over
            menuController.GameOver(); // Call GameOver method directly from MenuController
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("ScorePass"))
        {
            // Increase score when passing through the trigger
            IncreaseScore();
        }
    }

    private void IncreaseScore()
    {
        score++; // Increment score
        UpdateScoreUI(); // Update the UI
    }

    private void UpdateScoreUI()
    {
        // Update the TextMeshProUGUI with the current score
        if (scoreText != null)
        {
            scoreText.text = "" + score.ToString();
        }
    }
}
