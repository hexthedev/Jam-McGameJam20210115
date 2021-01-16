using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    bool jumpKeyPressed;
    bool onGround;
    bool canDoubleJump;
    float horizontalInput;
    public float jumpMultiplier = 100;
    public float fallMultiplier = 2;
    public float maxSpeed = 10;
    public float minSpeed = -10;
    public float changeDirectionReactivity = 4;
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
        if (Input.GetKeyDown(KeyCode.Space) )
        {
            jumpKeyPressed = true;
        }

        horizontalInput += Input.GetAxis("Horizontal") * Time.deltaTime * 20;
    }

    private void FixedUpdate()
    {       

        float horizontalVelocity = Mathf.Clamp(playerBody.velocity.x + horizontalInput * changeDirectionReactivity, minSpeed, maxSpeed);

        
        playerBody.velocity = new Vector2(horizontalVelocity, playerBody.velocity.y);

        

        if (playerBody.velocity.y < 0)
        {
            playerBody.velocity += Vector2.up * Physics.gravity.y * fallMultiplier  * Time.fixedDeltaTime;
        }

        if (playerBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
             playerBody.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
        }

        if (jumpKeyPressed)
        {
            
            if (onGround)
            {                
                playerBody.AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);              
                

                canDoubleJump = true;
            }

            else if (canDoubleJump)
            {
                canDoubleJump = false;
                if(playerBody.velocity.y < 0)
                {
                    playerBody.velocity = new Vector2(playerBody.velocity.x, 0);
                }
                
                playerBody.AddForce(Vector2.up * jumpMultiplier, ForceMode2D.Impulse);
            }
            jumpKeyPressed = false;
        }

        horizontalInput = 0;
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
