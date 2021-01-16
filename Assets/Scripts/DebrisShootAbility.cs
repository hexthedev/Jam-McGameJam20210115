using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisShootAbility : Ability
{
    public float projectileSpeed;

    public override void DoAbility()
    {
        float randomDirectionX = Random.Range(-1f, 1f);
        Vector3 direction = new Vector2(randomDirectionX, 1);
        GameObject projectile = Instantiate(projectilePrefab, transform.position + direction, Quaternion.identity);
        projectile.GetComponent<Rigidbody2D>().AddForce(direction * projectileSpeed);

    }
}
