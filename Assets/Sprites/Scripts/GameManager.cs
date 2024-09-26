using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public void GameOver()
    {
        gameOverUI.SetActive(true);  // Show Game Over UI
        Time.timeScale = 0;          // Pause the game
    }

    void Update()
    {
        // Restart the game when the player presses 'R'
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;  // Reset time scale
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
