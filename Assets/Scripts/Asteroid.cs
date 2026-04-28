using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float moveSpeed = 2f;
    private Vector2 velocity;
   
    void Start()
    {    
        float angle = Random.Range(0f, 360f);
        velocity = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * moveSpeed;
    }

    void Update()
    {
        transform.position += (Vector3)velocity * Time.deltaTime;
    }

}

   

    
