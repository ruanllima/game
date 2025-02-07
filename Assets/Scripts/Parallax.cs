using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float length;
    private float StartPosition;
    private Transform cam;
    public float ParallaxEffect;

    void Start()
    {
        StartPosition = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        cam = Camera.main.transform;
    }

    void Update()
    {   
        float RePos = cam.transform.position.x * (1 -  ParallaxEffect);
     // Move the background based on the camera's position
        float Distance = cam.transform.position.x * ParallaxEffect;
        transform.position = new Vector3(StartPosition + Distance, transform.position.y, transform.position.z);

    
        if (RePos > StartPosition + length){
            StartPosition += length;
        }
        else if (RePos < StartPosition - length){
            StartPosition -= length;
        }
    }   
}
