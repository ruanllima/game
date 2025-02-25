using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Apple : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private CircleCollider2D circleCollider;
    public GameObject collected;
    public int Score;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        circleCollider = GetComponent<CircleCollider2D>();
    }


    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {   
            spriteRenderer.enabled = false;
            circleCollider.enabled = false;
            collected.SetActive(true);

            gameController.instance.totalScore += Score;
            gameController.instance.updateScore();
            Destroy(gameObject, 0.29f);
        }
    }
}
