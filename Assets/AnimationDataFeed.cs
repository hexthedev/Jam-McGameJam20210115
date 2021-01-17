using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationDataFeed : MonoBehaviour
{
    public Animator anim;
    public Rigidbody2D rb;

    public void Update()
    {
        anim.SetFloat("XVelocity", Mathf.Abs(rb.velocity.x));
        anim.SetFloat("YVelocity",rb.velocity.y);

    }

}
