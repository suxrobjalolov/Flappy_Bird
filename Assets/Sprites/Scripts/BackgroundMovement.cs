using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public float moveSpeed = 0.2f;  // Speed at which the background moves
    public float respawnPositionX; // X position at which the background respawns
    public float startPositionX;   // X position where the background starts

    private Vector3 initialPosition;

    void Start()
    {
        // Store the initial position of the background
        initialPosition = transform.position;
        startPositionX = initialPosition.x;
        respawnPositionX = initialPosition.x - GetComponent<SpriteRenderer>().bounds.size.x; // Set respawn point based on size of background
    }

    void Update()
    {
        // Move the background left constantly
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);

        // Respawn the background once it has moved out of view
        if (transform.position.x <= respawnPositionX)
        {
            // Reset the position to the start to create a looping effect
            transform.position = new Vector3(startPositionX, transform.position.y, transform.position.z);
        }
    }
}
