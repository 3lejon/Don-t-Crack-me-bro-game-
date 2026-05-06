using UnityEngine;

public class TheWall : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float acceleration = 0.5f;
    private Vector2 velocity;
    private float currentSpeed;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentSpeed = moveSpeed;
        velocity = new Vector2(currentSpeed, 0); 
    }

    // Update is called once per frame
    void Update()
{
    if (Time.time >= 20f && Time.time < 50f)
    {
        currentSpeed += acceleration * Time.deltaTime;
        velocity = new Vector2(currentSpeed, 0);
    }
    else if (Time.time >= 50f)
    {
        velocity = Vector2.zero;
    }

    transform.Translate(velocity * Time.deltaTime);
}
}
