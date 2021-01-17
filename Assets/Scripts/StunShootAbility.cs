using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunShootAbility : Ability
{
    public float cooldown = 2f;

    public float projectileSpeed;

    public float cooldownTimer = 0;

    public override void DoAbility()
    {
        if(cooldownTimer <= 0)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position + Vector3.right, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().AddForce(Vector3.right * projectileSpeed);

            cooldownTimer = cooldown;
        }
    }

    protected override void Update()
    {
        base.Update();
    
        if(cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }
}
