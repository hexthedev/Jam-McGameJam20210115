using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitalCloud : MonoBehaviour
{
    public Rigidbody2D rb;

    public float minVelocity = 0.03f;
    public float maxVelocity = 0.06f;

    public void Start()
    {
        Vector3 vec3 = new Vector3(Random.Range(minVelocity, maxVelocity), 0, 0);
        rb.velocity = vec3;
    }
}
