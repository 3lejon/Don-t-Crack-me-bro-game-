using UnityEngine;

public class TheWall : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float acceleration = 0.5f;
    private Vector2 velocity;
    private float currentSpeed;
    private Collider2D wallCollider;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeed = moveSpeed;
        velocity = new Vector2(currentSpeed, 0);
        wallCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {   //after 20 seconds the wall acelerataes and turns of collider, and after 80 seconds hard stops
        if (Time.time >= 20f)
        {
            wallCollider.enabled = false;
            if (Time.time < 80f)
            {
                currentSpeed += acceleration * Time.deltaTime;
                velocity = new Vector2(currentSpeed, 0);
            }
            else
            {
                velocity = Vector2.zero;
            }
        }
        else
        {
            wallCollider.enabled = true;
        }

        transform.Translate(velocity * Time.deltaTime);
    }
}
