using UnityEngine;

public class PlatformUp : MonoBehaviour
{
    public float speed = 2f;
  
    void Update()
    {
    //moves the platform up at a constant speed
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
