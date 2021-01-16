using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisShootAbility : Ability
{
    [Range(-90, 0)]
    public float minAngle = -90;

    [Range(0, 90)]
    public float maxAngle = 90;

    public float minSpeed = 100;
    public float maxSpeed = 300;

    public override void DoAbility()
    {
        Quaternion rotation = Quaternion.Euler(0,0, Random.Range(minAngle, maxAngle));
        GameObject projectile = Instantiate(projectilePrefab, transform.position, rotation);
        projectile.GetComponent<Rigidbody2D>().AddRelativeForce(Random.Range(minSpeed, maxSpeed) * Vector3.up);


    }
}
