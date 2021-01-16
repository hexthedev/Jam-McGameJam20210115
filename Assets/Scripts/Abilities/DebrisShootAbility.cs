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

    [Range(0, 1f)]
    public float catChance = 0.25f;

    public GameObject catProjectile = null;

    public override void DoAbility()
    {
        Quaternion rotation = Quaternion.Euler(0,0, Random.Range(minAngle, maxAngle));

        GameObject projPrefab = Random.Range(0f, 1f) < catChance ? catProjectile : projectilePrefab;
        GameObject projectile = Instantiate(projPrefab, transform.position, rotation);

        projectile.GetComponent<Rigidbody2D>().AddRelativeForce(Random.Range(minSpeed, maxSpeed) * Vector3.up);
    }
}
