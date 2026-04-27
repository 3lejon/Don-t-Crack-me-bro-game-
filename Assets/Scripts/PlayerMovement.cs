using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovementController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 direction = Vector2.up;
    public float speed = 5f;

    [Header("Input")]// These variables are related to the input for movement in different directions
    
    
    public KeyCode inputLeft = KeyCode.A;
    public KeyCode inputRight = KeyCode.D;
    public KeyCode inputJump = KeyCode.Space;

    [Header("Jumping")]
    public float jumpForce = 5f;
    public float gravityScale = 1.5f;
    private float verticalVelocity = 0f;
    private bool isGrounded = false;
    public float groundDrag = 0.3f;

    [Header("Sprites")]// These variables are related to the different sprite renderers for each direction of movement
    public AnimatedSpriteRenderer spriteRendererJump;
   
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
     public AnimatedSpriteRenderer spriteRendererDeath;
     public AnimatedSpriteRenderer spriteRendererIdle;
    private AnimatedSpriteRenderer activeSpriteRenderer;

private void Awake()
{
    rb = GetComponent<Rigidbody2D>();

    activeSpriteRenderer = spriteRendererIdle;
     spriteRendererLeft.enabled = false;
}
    

    private void Update()// This method is called every frame to check for input and update the direction and active sprite renderer accordingly
    {
        
        if (Input.GetKey(inputLeft)) {
            SetDirection(Vector2.left, spriteRendererLeft);
        } else if (Input.GetKey(inputRight)) {
            SetDirection(Vector2.right, spriteRendererRight);
        }
        else if (Input.GetKeyDown(inputJump) && isGrounded)
        {
            SetDirection(Vector2.up, spriteRendererJump);
        }
        else
        {
            SetDirection(Vector2.zero, activeSpriteRenderer);
        }

        // Handle jump input
        if (Input.GetKeyDown(inputJump) && isGrounded)
        {
            verticalVelocity = jumpForce;
            isGrounded = false;
        }
    }

    private void FixedUpdate()
    {
        // Check if player is grounded
        CheckGround();

        // Apply gravity
        verticalVelocity -= Physics2D.gravity.y * gravityScale * Time.fixedDeltaTime;

        // Apply ground drag to reduce velocity when grounded
        if (isGrounded && verticalVelocity < 0)
        {
            verticalVelocity *= (1f - groundDrag);
        }

        Vector2 position = rb.position;
        Vector2 translation = speed * Time.fixedDeltaTime * direction;
        translation.y = verticalVelocity * Time.fixedDeltaTime;

        rb.MovePosition(position + translation);
    }

    private void SetDirection(Vector2 newDirection, AnimatedSpriteRenderer spriteRenderer)// This method is called to set the direction of movement and the active sprite renderer based on the input
    {
        direction = newDirection;

        
        spriteRendererLeft.enabled = spriteRenderer == spriteRendererLeft;
        spriteRendererRight.enabled = spriteRenderer == spriteRendererRight;
        spriteRendererJump.enabled = spriteRenderer == spriteRendererJump;
        spriteRendererIdle.enabled = spriteRenderer == spriteRendererIdle;

        activeSpriteRenderer = spriteRenderer;
        activeSpriteRenderer.idle = direction == Vector2.zero;
    }

    private void CheckGround()
    {
        // Cast a ray downward to check if grounded
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, 0.1f);
        isGrounded = hit.collider != null;

        // Reset vertical velocity when hitting the ground
        if (isGrounded && verticalVelocity <= 0)
        {
            verticalVelocity = 0f;
        }
    }

   
   
    
}