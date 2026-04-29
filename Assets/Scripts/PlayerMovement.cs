using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] private float speed;
    [SerializeField] private float jumpCooldown = 0.5f;
    [SerializeField] private float jumpForce;
    [SerializeField] private KeyCode inputJump = KeyCode.Space;
    [SerializeField] private KeyCode inputLeft = KeyCode.A;
    [SerializeField] private KeyCode inputRight = KeyCode.D;
    private Rigidbody2D body;
    private float jumpTimer;

    [Header("Sprites")]// These variables are related to the different sprite renderers for each direction of movement
   
    public AnimatedSpriteRenderer spriteRendererJump;
    public AnimatedSpriteRenderer spriteRendererLeft;
    public AnimatedSpriteRenderer spriteRendererRight;
     public AnimatedSpriteRenderer spriteRendererDeath;
    private AnimatedSpriteRenderer activeSpriteRenderer;
 
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
 
    private void SetDirection(Vector2 direction, AnimatedSpriteRenderer spriteRenderer)
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
        float vertical = Input.GetAxis("Vertical");
        body.linearVelocity = new Vector2(horizontal * speed, vertical * speed);
        if (jumpTimer > 0f)
            jumpTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && jumpTimer <= 0f)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, jumpForce);
            jumpTimer = jumpCooldown;
            SetDirection(Vector2.up, spriteRendererJump);
        }
        else if (Input.GetKey(inputLeft))
        {
            SetDirection(Vector2.left, spriteRendererLeft);
        }
        else if (Input.GetKey(inputRight))
        {
            SetDirection(Vector2.right, spriteRendererRight);
        }
        else
        {
            SetDirection(Vector2.zero, activeSpriteRenderer);
        }
    }
}