using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    private float startPos, length;
    public GameObject target;
    public GameObject cam;
    public float ParallaxEffect;
    private float upPos;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void FixedUpdate()
    {   
        
        float Distance = target.transform.position.x * ParallaxEffect;
        float movement = cam.transform.position.x; /* * (1 - ParallaxEffect);*/
        transform.position = new Vector3(startPos + Distance, transform.position.y, transform.position.z);
        
        if(movement > startPos + length)
        {
            startPos += length;
        }
        else if(movement < startPos - length)
        {
            startPos -= length;
        }

    }   
}
