using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDataFeed : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;
    public PlayerController pc;

    public void Update()
    {
        anim.SetFloat("XVelocity", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("YVelocity",rb.velocity.y);

        if (!pc.onGround)
        {
            anim.SetBool("OnSecondJump", pc.canDoubleJump);
        }
        else
        {
            anim.SetBool("OnSecondJump", false);
        }

    }

    public void HandleJumpHappens()
    {
        anim.SetTrigger("Jump");
    }
}
