using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public float Speed;
    public float JumpForce;
    public bool isJumping;
    public bool doubleJump;
    private InputAction jumpAction;
    private Rigidbody2D rig;
    private Animator anim;
    public GameObject anyCanvas;
    private bool activeanyCanvas = false;

    private void Awake()
    {  
        var playerInput = GetComponent<PlayerInput>();
        jumpAction = playerInput.actions["Jump"];
    }

    void Start()
    {   
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {   

        // Block the player movement if any canvas is active
        if(anyCanvas != null)
        {
            activeanyCanvas = anyCanvas.activeSelf;

        }
        if(!activeanyCanvas){
            Move();
            Jump();
        }
    }

    void Move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Speed * Time.deltaTime;

        if(!isJumping)
        {
            if(Input.GetAxis("Horizontal") > 0f){
                anim.SetBool("run", true);
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }

            if(Input.GetAxis("Horizontal") < 0f){
                anim.SetBool("run", true);
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }

            if(Input.GetAxis("Horizontal") == 0f){
                anim.SetBool("run", false);
            }
        }
    }

    void Jump(){
        if(jumpAction.WasPressedThisFrame())
        {

            if(!isJumping)
            {
                rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if(doubleJump)
                {
                    rig.AddForce(new Vector2(0f, JumpForce * 0.6f), ForceMode2D.Impulse);
                    doubleJump = false;
                    anim.SetBool("jump", true);
                }
            }

        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.layer == 7){
            isJumping = false;
            anim.SetBool("jump", false);
        }

        if(collision.gameObject.tag == "Win")
        {
            gameController.instance.showWinCanvas();
            Destroy(gameObject); 

        }

        if(collision.gameObject.tag == "Spike")
        {
            gameController.instance.showLoseCanvas();
            Destroy(gameObject); 
        }


    }

    void OnCollisionExit2D(Collision2D collision){
        if(collision.gameObject.layer == 7){
            isJumping = true;
            anim.SetBool("run", false);
        }
    }
}
