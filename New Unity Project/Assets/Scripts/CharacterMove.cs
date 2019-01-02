using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

    // Player Movement Variables
    public int MoveSpeed;
    public float JumpHeight;
    private bool doubleJump;

    // Player Grounded Variables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    //Non-stick Player
    private float moveVelocity;

    public Animator animator;


    // Use this for initialization
    void Start () {
        animator.SetBool("isWalking", false);
        animator.SetBool("isJumping", false);
    }
    
    
    // FixedUpdate is called once per cycle
    void FixedUpdate() {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Update is called once per frame
    void Update()
    {
         // This code makes the character jump
        if(Input.GetKeyDown (KeyCode.Space)&& grounded){
            Jump();
        }

        // Double jump code
        if(grounded)
            doubleJump = false;

        if (Input.GetKeyDown(KeyCode.Space)&& !doubleJump && !grounded){
            Jump();
            doubleJump = true;
        }

            // Non-stick player
            moveVelocity = 0f;



        // This code makes the character move side to side using the a&d keys
        if(Input.GetKey (KeyCode.D))
        {
                //GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
                moveVelocity = MoveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            moveVelocity = -MoveSpeed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

        if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(0.1117748f, 0.1117748f, 0.1117748f);
        else if (GetComponent<Rigidbody2D>().velocity.x < 0)
            transform.localScale = new Vector3(-0.1117748f, 0.1117748f, 0.1117748f);
    }

    public void Jump(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
        animator.SetBool("isJumping", true);
    }
}
