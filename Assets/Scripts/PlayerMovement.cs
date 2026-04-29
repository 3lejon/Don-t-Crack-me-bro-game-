using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float jumpCooldown = 0.5f;
    [SerializeField] private KeyCode inputJump = KeyCode.Space;
    [SerializeField] private KeyCode inputLeft = KeyCode.A;
    [SerializeField] private KeyCode inputRight = KeyCode.D;

    private Rigidbody2D body;
    private float jumpTimer;

    [Header("Sprites")]
    public AnimatedSpriteRenderer spriteRendererJump;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
    public AnimatedSpriteRenderer spriteRendererDeath;

    private AnimatedSpriteRenderer activeSpriteRenderer;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        activeSpriteRenderer = spriteRendererRight; // default
    }

    private void SetDirection(AnimatedSpriteRenderer spriteRenderer)
    {
        if (activeSpriteRenderer != null)
            activeSpriteRenderer.enabled = false;

        activeSpriteRenderer = spriteRenderer;

        if (activeSpriteRenderer != null)
            activeSpriteRenderer.enabled = true;
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        // Horizontal movement (same as your first script)
        body.velocity = new Vector2(horizontal * speed, body.velocity.y);

        // Jump cooldown timer
        if (jumpTimer > 0f)
            jumpTimer -= Time.deltaTime;

        // Jump
        if (Input.GetKeyDown(inputJump) && jumpTimer <= 0f)
        {
            body.velocity = new Vector2(body.velocity.x, jumpForce);
            jumpTimer = jumpCooldown;
            SetDirection(spriteRendererJump);
        }
        else if (Input.GetKey(inputLeft))
        {
            SetDirection(spriteRendererLeft);
        }
        else if (Input.GetKey(inputRight))
        {
            SetDirection(spriteRendererRight);
        }
        else
        {
            // Idle keeps last direction sprite
            SetDirection(activeSpriteRenderer);
        }
    }
}
