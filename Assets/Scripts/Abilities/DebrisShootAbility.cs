using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisShootAbility : Ability
{
    [Range(-90, 0)]
    public float minDebrisAngle = -90;

    [Range(0, 90)]
    public float maxDebrisAngle = 90;

    [Range(-10, 0)]
    public float minCatAngle = -90;

    [Range(0, 10)]
    public float maxCatAngle = 90;

    public float minSpeed = 100;
    public float maxSpeed = 300;

    [Range(0, 1f)]
    public float catChance = 0.25f;

    public GameObject catProjectile = null;

    public override void DoAbility()
    {
        if (Random.Range(0f, 1f) < catChance)
        {
            Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(minCatAngle, maxCatAngle)); // change the angle to what you want
            GameObject pro = Instantiate(catProjectile, transform.position, rotation);
            pro.GetComponent<Rigidbody2D>().AddRelativeForce(Random.Range(minSpeed, maxSpeed) * Vector3.up); // change the amount of force
        }
        else
        {
            Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(minDebrisAngle, maxDebrisAngle));
            GameObject pro = Instantiate(projectilePrefab, transform.position, rotation);
            pro.GetComponent<Rigidbody2D>().AddRelativeForce(Random.Range(minSpeed, maxSpeed) * Vector3.up);
        }

    }
}
