using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunShootAbility : Ability
{
    public float projectileSpeed;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DoAbility();
        }
    }
    public override void DoAbility()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position + Vector3.right, Quaternion.identity);
        projectile.GetComponent<Rigidbody>().AddForce(Vector3.forward * projectileSpeed);

    }
}
