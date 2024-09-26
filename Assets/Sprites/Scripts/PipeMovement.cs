using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float moveSpeed = 2f;    // Speed at which the obstacle moves left
    public float deadZone = -10f;   // The X position where the obstacle gets destroyed

    void Update()
    {
        // Move the entire obstacle to the left
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;

        // Destroy the obstacle when it moves out of view
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
