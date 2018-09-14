using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

    // Player Movement Variables
    public int MoveSpeed;
    public float JumpHeight;

    // Player Grounded Variables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;


    // Use this for initialization
    void Start () {
        
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

        // This code makes the character move side to side using the a&d keys
        if(Input.GetKey (KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

    }

    public void Jump(){
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, JumpHeight);
    }
}
