using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float thrustForce = 8f;       // Forward thrust
    public float rotationSpeed = 300f;   // Rotation speed
    public float maxSpeed = 10f;         // Maximum speed
    public float drag = 0.95f;           // Drag to slow down over time

    
    private Rigidbody2D rb;
  

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D not found on Player!");
        }
    }

    void Update()
    {
        HandleRotation();
        HandleThrust();
        
    }

    void FixedUpdate()
    {
        // Apply drag to slow down
        rb.linearVelocity *= drag;

        // Clamp max speed
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    void HandleRotation()
    {
        float rotationInput = Input.GetAxis("Horizontal"); // Uses GetAxis for smoother input
        rb.rotation += rotationInput * rotationSpeed * Time.deltaTime;
    }

    void HandleThrust()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D))
        {
            Vector2 force = transform.up * thrustForce;
            rb.AddForce(force);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            // Player hit an asteroid = boom
            if (Lives.Instance != null)
            {
                Lives.Instance.PlayerDied();
            }
            Destroy(gameObject);
        }
    }
}