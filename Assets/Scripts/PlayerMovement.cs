using UnityEngine;
 
public class PlayerMovement : MonoBehaviour
{ 
    [SerializeField] private float speed;
    [SerializeField] private float jumpCooldown = 0.5f;
    private Rigidbody2D body;
    private float jumpTimer;
 
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
 
    private void Update()
    {
        body.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.linearVelocity.y);
 
        if (jumpTimer > 0f)
            jumpTimer -= Time.deltaTime;
 
        if (Input.GetKeyDown(KeyCode.Space) && jumpTimer <= 0f)
        {
            body.linearVelocity = new Vector2(body.linearVelocity.x, speed);
            jumpTimer = jumpCooldown;
        }
    }
}