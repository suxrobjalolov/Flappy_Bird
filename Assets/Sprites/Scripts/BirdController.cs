using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float flapForce = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button or screen tap
        {
            Flap();
        }
    }

    void Flap()
    {
        rb.velocity = Vector2.up * flapForce;
    }
}
