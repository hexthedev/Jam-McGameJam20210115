using UnityEngine;

public class ScaleFliper : MonoBehaviour
{
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        float xVel = rb.velocity.x;

        if(xVel < -0.01f)
        {
            transform.localScale = new Vector3(-0.35f, 0.35f, 0.35f);
        } 
        else if(xVel > 0.01f)
        {
            transform.localScale = new Vector3(0.35f, 0.35f, 0.35f);
        }
    }
}
