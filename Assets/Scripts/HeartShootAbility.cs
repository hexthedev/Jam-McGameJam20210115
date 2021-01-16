using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartShootAbility : Ability
{
    private List<Vector3> projectileDirections;

    public float projectileSpeed;

    private void Start()
    {
        projectileDirections = new List<Vector3>();
        projectileDirections.Add(Vector3.left);
        projectileDirections.Add(Vector3.right);
        projectileDirections.Add(Vector3.up);
        projectileDirections.Add(Vector3.down);
        projectileDirections.Add(Vector3.up + Vector3.left);
        projectileDirections.Add(Vector3.up + Vector3.right);
        projectileDirections.Add(Vector3.down + Vector3.left);
        projectileDirections.Add(Vector3.down + Vector3.right);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            DoAbility();
        }
    }
    public override void DoAbility()
    {
        foreach(Vector3 direction in projectileDirections)
        {
            GameObject projectile = Instantiate(projectilePrefab, transform.position + direction, Quaternion.identity);
            projectile.GetComponent<Rigidbody>().AddForce(direction * projectileSpeed);
        }
        
    }
}
