using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject startButton;       // Reference to the Start button
    public GameObject gameOverText;      // Reference to the Game Over text
    public GameObject restartButton;     // Reference to the Restart button
    public GameObject exitButton;        // Reference to the Exit button
    public GameObject bird;               // Reference to the bird GameObject
    public GameObject pipes;              // Reference to the pipes or obstacles
    public GameObject panel;              // Reference to the panel

    void Start()
    {
        // Set the time scale to 0 when the game starts
        Time.timeScale = 0;

        // Show the Start button and hide Game Over text and Restart button
        startButton.SetActive(true);
        gameOverText.SetActive(false);
        restartButton.SetActive(false);
        exitButton.SetActive(false);
    }

    public void StartGame()
    {
        // Hide the Start button and set time scale to 1
        startButton.SetActive(false);
        exitButton.SetActive(false); // Optionally hide exit button
        panel.SetActive(false); // Optionally hide panel
        Time.timeScale = 1;

        // Reset the game state
        ResetGame();
    }

    public void GameOver() // Exposed GameOver method
    {
        // Show Game Over text and Restart button
        gameOverText.SetActive(true);
        exitButton.SetActive(true);
        panel.SetActive(true);
        restartButton.SetActive(true);
        Time.timeScale = 0; // Pause the game
    }

    public void RestartGame()
    {
        // Reset the game state
        ResetGame();

        // Restart the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        // Exit the application (works in a built application)
        Application.Quit();

        // In the editor, stop playing
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    private void ResetGame()
    {
        // Reset the bird's position and state
        if (bird != null)
        {
            bird.transform.position = new Vector3(-1, 0, -1); // Set to starting position (adjust as needed)
            bird.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // Reset velocity
        }

        // Reset pipes or any other game objects as needed
        if (pipes != null)
        {
            foreach (Transform pipe in pipes.transform)
            {
                // Reset the position of each pipe if necessary
                pipe.transform.position = new Vector3(pipe.transform.position.x, pipe.transform.position.y, pipe.transform.position.z);
            }
        }
    }
}
