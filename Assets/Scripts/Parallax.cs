using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Parallax : MonoBehaviour
{
   private float startPos;
   public GameObject cam; 
    public float parallaxEffect;
    

    void start()
    {
        startPos = transform.position.x;
    }
    
    void update()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}