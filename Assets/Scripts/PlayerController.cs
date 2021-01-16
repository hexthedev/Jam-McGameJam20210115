using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{       
    bool onGround;
    bool canDoubleJump;
    bool jumpKeyPressed;
    bool goLeft;
    bool goRight;    
    
    public float jumpMultiplier = 100f;
    public float fallMultiplier = 2f;
    public float moveSpeed = 10f;
    public float maxSpeed = 10f;
    public float minSpeed = -10f;    
    public float airControl = 5f;
    public KeyCode jump;
    public KeyCode left;
    public KeyCode right;

    Rigidbody2D playerBody;
    


    // Start is called before the first frame update
    void Start()
    {
        onGround = true;
        playerBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get user movement input
        if (Input.GetKeyDown(jump))
        {
            jumpKeyPressed = true;
        }
        else if (Input.GetKey(left))
        {
            goLeft = true;
        }
        else if (Input.GetKey(right))
        {
            goRight = true;
        }

        

    }

    private void FixedUpdate()
    {
        
        //Do user movement
        float horizontalVelocity; 

        //Control if not jumping/falling
        if(playerBody.velocity.y == 0 && goLeft)
        {
            horizontalVelocity = Mathf.Clamp(playerBody.velocity.x - moveSpeed , minSpeed, maxSpeed);
            playerBody.velocity = new Vector2(horizontalVelocity, playerBody.velocity.y);
            goLeft = false;
        }
        if(playerBody.velocity.y == 0 && goRight)
        {
            horizontalVelocity = Mathf.Clamp(playerBody.velocity.x + moveSpeed, minSpeed, maxSpeed);
            playerBody.velocity = new Vector2(horizontalVelocity, playerBody.velocity.y);
            goRight = false;
        }
        
        //Control if jumping/falling
        if (playerBody.velocity.y != 0 && goLeft)
        {
            horizontalVelocity = Mathf.Clamp(playerBody.velocity.x - (moveSpeed /airControl), minSpeed, maxSpeed);
            playerBody.velocity = new Vector2(horizontalVelocity, playerBody.velocity.y);
            goLeft = false;
        }

        if (playerBody.velocity.y != 0 && goRight)
        {
            horizontalVelocity = Mathf.Clamp(playerBody.velocity.x + (moveSpeed /airControl), minSpeed, maxSpeed);
            playerBody.velocity = new Vector2(horizontalVelocity, playerBody.velocity.y);
            goRight = false;
        }

        if (jumpKeyPressed)
        {
            //Ground Jump
            if (onGround)
            {
                playerBody.AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);


                canDoubleJump = true;
            }
            //Double jump
            else if (canDoubleJump)
            {
                canDoubleJump = false;

                playerBody.velocity = new Vector2(playerBody.velocity.x, 0);
                playerBody.AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);
            }
            jumpKeyPressed = false;
        }

        //Cleaner fall mechanic
        if (playerBody.velocity.y < 0)
        {
            playerBody.velocity += Vector2.up * Physics.gravity.y * fallMultiplier  * Time.fixedDeltaTime;
        }

        if (playerBody.velocity.y > 0 && !Input.GetKey(jump))
        {
             playerBody.velocity += Vector2.up * Physics.gravity.y  * Time.fixedDeltaTime;
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onGround = false;
        }
    }
}
