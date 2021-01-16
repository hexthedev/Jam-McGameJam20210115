using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartShootAbility : Ability
{
    private List<Vector2> projectileDirections;

    public float projectileSpeed;

    private void Start()
    {
        projectileDirections = new List<Vector2>();
        projectileDirections.Add(Vector2.left);
        projectileDirections.Add(Vector2.right);
        projectileDirections.Add(Vector2.up);
        projectileDirections.Add(Vector2.down);
        projectileDirections.Add(Vector2.up + Vector2.left);
        projectileDirections.Add(Vector2.up + Vector2.right);
        projectileDirections.Add(Vector2.down + Vector2.left);
        projectileDirections.Add(Vector2.down + Vector2.right);
    }

    public override void DoAbility()
    {
        foreach(Vector2 direction in projectileDirections)
        {
            GameObject projectile = Instantiate(projectilePrefab, (Vector2)transform.position + direction, Quaternion.identity);
            projectile.GetComponent<Rigidbody2D>().AddForce(direction * projectileSpeed);
        }
        
    }
}
